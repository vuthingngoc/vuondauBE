using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using VuonDau.Business.Requests.HarvestSelling;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using System;
using VuonDau.Data.Common.Enum;
using Reso.Core.Utilities;
using System.Linq;

namespace VuonDau.Business.Services
{
    public partial interface IHarvestSellingService
    {
        Task<List<HarvestSellingViewModel>> GetAllHarvestSellings(SearchHarvestSellingRequest request);
        Task<HarvestSellingViewModel> GetHarvestSellingById(Guid id);
        Task<List<HarvestSellingViewModel>> GetHarvestSellingByHarvestId(Guid id);
        Task<HarvestSellingViewModel> CreateHarvestSelling(CreateHarvestSellingRequest request);
        Task<HarvestSellingViewModel> UpdateHarvestSelling(Guid id, UpdateHarvestSellingRequest request);
        Task<int> DeleteHarvestSelling(Guid id);
    }


    public partial class HarvestSellingService
    {
        private readonly IConfigurationProvider _mapper;

        public HarvestSellingService(IUnitOfWork unitOfWork, IHarvestSellingRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<HarvestSellingViewModel>> GetAllHarvestSellings(SearchHarvestSellingRequest request)
        {
            if(request.Status == null)
            {
                if(request.HarvestId == null)
                {
                    if(request.endDate == null)
                    {
                        HarvestSellingViewModel filter = new HarvestSellingViewModel();
                        return await Get()
                            .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<HarvestSellingViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
                    }
                    return await Get(o => o.DateOfCreate >= request.endDate)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<HarvestSellingViewModel>(_mapper).ToListAsync();
                } else
                {
                    if (request.endDate == null)
                    {
                        return await Get(o => o.HarvestId == request.HarvestId)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<HarvestSellingViewModel>(_mapper).ToListAsync();
                    }
                    return await Get(o => o.DateOfCreate >= request.endDate && o.HarvestId == request.HarvestId)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<HarvestSellingViewModel>(_mapper).ToListAsync();
                }
            } else
            {
                if (request.HarvestId == null)
                {
                    if (request.endDate == null)
                    {
                        HarvestSellingViewModel filter = new HarvestSellingViewModel();
                        return await Get(o => o.Status == request.Status)
                            .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<HarvestSellingViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
                    }
                    return await Get(o => o.DateOfCreate >= request.endDate && o.Status == request.Status)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<HarvestSellingViewModel>(_mapper).ToListAsync();
                }
                else
                {
                    if (request.endDate == null)
                    {
                        return await Get(o => o.HarvestId == request.HarvestId && o.Status == request.Status)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<HarvestSellingViewModel>(_mapper).ToListAsync();
                    }
                    return await Get(o => o.DateOfCreate >= request.endDate && o.HarvestId == request.HarvestId && o.Status == request.Status)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<HarvestSellingViewModel>(_mapper).ToListAsync();
                }
            }
        }
        public async Task<HarvestSellingViewModel> GetHarvestSellingById(Guid id)
        {
            return await Get(p => p.Id == id).OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<HarvestSellingViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<List<HarvestSellingViewModel>> GetHarvestSellingByHarvestId(Guid HarvestId)
        {
            return await Get(p => p.HarvestId == HarvestId).OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<HarvestSellingViewModel>(_mapper).ToListAsync();
        }
        public async Task<HarvestSellingViewModel> CreateHarvestSelling(CreateHarvestSellingRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var harvestSelling = mapper.Map<HarvestSelling>(request);
            harvestSelling.Status = (int)Status.Active;
            await CreateAsyn(harvestSelling);
            var harvestSellingViewModel = mapper.Map<HarvestSellingViewModel>(harvestSelling);
            return harvestSellingViewModel;
        }

        public async Task<HarvestSellingViewModel> UpdateHarvestSelling(Guid id, UpdateHarvestSellingRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var harvestSellingInRequest = mapper.Map<HarvestSelling>(request);
            var harvestSelling = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (harvestSelling == null)
            {
                return null;
            }
            harvestSelling.HarvestId = harvestSellingInRequest.HarvestId;
            harvestSelling.CampaignId = harvestSellingInRequest.CampaignId;
            harvestSelling.DateOfCreate = harvestSellingInRequest.DateOfCreate;
            harvestSelling.EndDate = harvestSellingInRequest.EndDate;
            harvestSelling.MinWeight = harvestSellingInRequest.MinWeight;
            harvestSelling.TotalWeight = harvestSellingInRequest.TotalWeight;
            harvestSelling.Status = harvestSellingInRequest.Status;
            await UpdateAsyn(harvestSelling);
            return mapper.Map<HarvestSellingViewModel>(harvestSelling);
        }

        public async Task<int> DeleteHarvestSelling(Guid id)
        {
            var harvestSelling = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (harvestSelling == null)
            {
                return 0;
            }
            await UpdateAsyn(harvestSelling);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
