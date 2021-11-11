using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Harvest;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Reso.Core.Utilities;
using System.Linq;

namespace VuonDau.Business.Services
{
    public partial interface IHarvestService
    {
        Task<List<HarvestViewModel>> GetAllHarvests(SearchHarvestRequest request);
        Task<HarvestViewModel> GetHarvestById(Guid id);
        Task<List<HarvestViewModel>> GetHarvestByFarmId(Guid id);
        Task<List<HarvestViewModel>> GetHarvestByProductId(Guid id);
        Task<HarvestViewModel> CreateHarvest(CreateHarvestRequest request);
        Task<HarvestViewModel> UpdateHarvest(Guid id, UpdateHarvestRequest request);
        Task<int> DeleteHarvest(Guid id);
    }


    public partial class HarvestService
    {
        private readonly IConfigurationProvider _mapper;

        public HarvestService(IUnitOfWork unitOfWork, IHarvestRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<HarvestViewModel>> GetAllHarvests(SearchHarvestRequest request)
        {
            request.Name = request.Name == null ? "" : request.Name;
            if (request.Status == null)
            {
                if (request.FarmId == null)
                {
                    if (request.ProductTypeId == null)
                    {
                        return await Get(c => c.Name.Contains(request.Name))
                    .OrderBy(c => c.Name).OrderByDescending(c => c.Status).ProjectTo<HarvestViewModel>(_mapper).ToListAsync();
                    }
                    return await Get(c => c.Name.Contains(request.Name) && c.Product.ProductTypeId == request.ProductTypeId)
                    .OrderBy(c => c.Name).OrderByDescending(c => c.Status).ProjectTo<HarvestViewModel>(_mapper).ToListAsync();
                }
                if (request.ProductTypeId == null)
                {
                    return await Get(c => c.Name.Contains(request.Name) && c.FarmId == request.FarmId)
                .OrderBy(c => c.Name).OrderByDescending(c => c.Status).ProjectTo<HarvestViewModel>(_mapper).ToListAsync();
                }
                return await Get(c => c.Name.Contains(request.Name) && c.FarmId == request.FarmId && c.Product.ProductTypeId == request.ProductTypeId)
                    .OrderBy(c => c.Name).OrderByDescending(c => c.Status).ProjectTo<HarvestViewModel>(_mapper).ToListAsync();
            }
            else
            {
                if (request.FarmId == null)
                {
                    if (request.ProductTypeId == null)
                    {
                        return await Get(c => c.Name.Contains(request.Name) && c.Status == request.Status)
                    .OrderBy(c => c.Name).OrderByDescending(c => c.Status).ProjectTo<HarvestViewModel>(_mapper).ToListAsync();
                    }
                    return await Get(c => c.Name.Contains(request.Name) && c.Product.ProductTypeId == request.ProductTypeId && c.Status == request.Status)
                    .OrderBy(c => c.Name).OrderByDescending(c => c.Status).ProjectTo<HarvestViewModel>(_mapper).ToListAsync();
                }
                if (request.ProductTypeId == null)
                {
                    return await Get(c => c.Name.Contains(request.Name) && c.FarmId == request.FarmId && c.Status == request.Status)
                .OrderBy(c => c.Name).OrderByDescending(c => c.Status).ProjectTo<HarvestViewModel>(_mapper).ToListAsync();
                }
                return await Get(c => c.Name.Contains(request.Name) && c.FarmId == request.FarmId && c.Product.ProductTypeId == request.ProductTypeId && c.Status == request.Status)
                    .OrderBy(c => c.Name).OrderByDescending(c => c.Status).ProjectTo<HarvestViewModel>(_mapper).ToListAsync();
            }
        }

        public async Task<HarvestViewModel> GetHarvestById(Guid id)
        {
            return await Get(p => p.Id == id).OrderBy(c => c.Name).OrderByDescending(c => c.Status).ProjectTo<HarvestViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<List<HarvestViewModel>> GetHarvestByFarmId(Guid FarmId)
        {
            return await Get(p => p.FarmId == FarmId).OrderBy(c => c.Name).OrderByDescending(c => c.Status).ProjectTo<HarvestViewModel>(_mapper).ToListAsync();
        }
        public async Task<List<HarvestViewModel>> GetHarvestByProductId(Guid ProductId)
        {
            return await Get(p => p.ProductId == ProductId).OrderBy(c => c.Name).OrderByDescending(c => c.Status).ProjectTo<HarvestViewModel>(_mapper).ToListAsync();
        }

        public async Task<HarvestViewModel> CreateHarvest(CreateHarvestRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var harvest = mapper.Map<Harvest>(request);
            harvest.Status = (int)Status.Active;
            await CreateAsyn(harvest);
            var harvestViewModel = mapper.Map<HarvestViewModel>(harvest);
            return harvestViewModel;
        }

        public async Task<HarvestViewModel> UpdateHarvest(Guid id, UpdateHarvestRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var harvestInRequest = mapper.Map<Harvest>(request);
            var harvest = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (harvest == null)
            {
                return null;
            }
            harvest.Name = harvestInRequest.Name;
            harvest.FarmId = harvestInRequest.FarmId;
            harvest.ProductId = harvestInRequest.ProductId;
            harvest.Description = harvestInRequest.Description;
            harvest.Status = harvestInRequest.Status;
            await UpdateAsyn(harvest);
            return mapper.Map<HarvestViewModel>(harvest);
        }

        public async Task<int> DeleteHarvest(Guid id)
        {
            var harvest = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (harvest == null)
            {
                return 0;
            }
            await UpdateAsyn(harvest);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}