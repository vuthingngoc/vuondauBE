using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using VuonDau.Business.Requests.HarvestSellingPrice;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using System;
using VuonDau.Data.Common.Enum;
using Reso.Core.Utilities;
using System.Linq;

namespace VuonDau.Business.Services
{
    public partial interface IHarvestSellingPriceService
    {
        Task<List<HarvestSellingPriceViewModel>> GetAllHarvestSellingPrices(SearchHarvestSellingPriceRequest request);
        Task<HarvestSellingPriceViewModel> GetHarvestSellingPriceById(Guid id);
        Task<List<HarvestSellingPriceViewModel>> GetHarvestSellingPriceByHarvestSellingId(Guid id);
        Task<HarvestSellingPriceViewModel> CreateHarvestSellingPrice(CreateHarvestSellingPriceRequest request);
        Task<HarvestSellingPriceViewModel> UpdateHarvestSellingPrice(Guid id, UpdateHarvestSellingPriceRequest request);
        Task<int> DeleteHarvestSellingPrice(Guid id);
    }


    public partial class HarvestSellingPriceService
    {
        private readonly IConfigurationProvider _mapper;

        public HarvestSellingPriceService(IUnitOfWork unitOfWork, IHarvestSellingPriceRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<HarvestSellingPriceViewModel>> GetAllHarvestSellingPrices(SearchHarvestSellingPriceRequest request)
        {
            if (request.HarvesrSellingId == null)
            {
                if(request.startPrice == null && request.endPrice == null)
                {
                    HarvestSellingPriceViewModel filter = new HarvestSellingPriceViewModel();
                    return await Get().OrderByDescending(o => o.Status).OrderBy(o => o.Price).ProjectTo<HarvestSellingPriceViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
                }
                if(request.startPrice == null)
                {
                    return await Get(o => o.Price <= request.endPrice)
                   .OrderByDescending(o => o.Status).OrderBy(o => o.Price).ProjectTo<HarvestSellingPriceViewModel>(_mapper).ToListAsync();
                }
                if(request.endPrice == null)
                {
                    return await Get(o => o.Price >= request.startPrice)
                   .OrderByDescending(o => o.Status).OrderBy(o => o.Price).ProjectTo<HarvestSellingPriceViewModel>(_mapper).ToListAsync();
                }
                return await Get(o => o.Price >= request.startPrice && o.Price <= request.endPrice)
                   .OrderByDescending(o => o.Status).OrderBy(o => o.Price).ProjectTo<HarvestSellingPriceViewModel>(_mapper).ToListAsync();
            }
            else
            {
                if (request.startPrice == null && request.endPrice == null)
                {
                    return await Get(o => o.HarvestSellingId == request.HarvesrSellingId)
                   .OrderByDescending(o => o.Status).OrderBy(o => o.Price).ProjectTo<HarvestSellingPriceViewModel>(_mapper).ToListAsync();
                }
                if (request.startPrice == null)
                {
                    return await Get(o => o.Price <= request.endPrice && o.HarvestSellingId == request.HarvesrSellingId)
                   .OrderByDescending(o => o.Status).OrderBy(o => o.Price).ProjectTo<HarvestSellingPriceViewModel>(_mapper).ToListAsync();
                }
                if (request.endPrice == null)
                {
                    return await Get(o => o.Price >= request.startPrice && o.HarvestSellingId == request.HarvesrSellingId)
                   .OrderByDescending(o => o.Status).OrderBy(o => o.Price).ProjectTo<HarvestSellingPriceViewModel>(_mapper).ToListAsync();
                }
                return await Get(o => o.Price >= request.startPrice && o.Price <= request.endPrice && o.HarvestSellingId == request.HarvesrSellingId)
                   .OrderByDescending(o => o.Status).OrderBy(o => o.Price).ProjectTo<HarvestSellingPriceViewModel>(_mapper).ToListAsync();
            }
        }

        public async Task<HarvestSellingPriceViewModel> GetHarvestSellingPriceById(Guid id)
        {
            return await Get(p => p.Id == id).OrderByDescending(o => o.Status).OrderBy(o => o.Price).ProjectTo<HarvestSellingPriceViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<List<HarvestSellingPriceViewModel>> GetHarvestSellingPriceByHarvestSellingId(Guid HarvestSellingId)
        {
            return await Get(p => p.HarvestSellingId == HarvestSellingId).OrderByDescending(o => o.Status).OrderBy(o => o.Price).ProjectTo<HarvestSellingPriceViewModel>(_mapper).ToListAsync();
        }
        public async Task<HarvestSellingPriceViewModel> CreateHarvestSellingPrice(CreateHarvestSellingPriceRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var harvestSellingPrice = mapper.Map<HarvestSellingPrice>(request);
            harvestSellingPrice.Status = (int)Status.Active;
            await CreateAsyn(harvestSellingPrice);
            var harvestSellingPriceViewModel = mapper.Map<HarvestSellingPriceViewModel>(harvestSellingPrice);
            return harvestSellingPriceViewModel;
        }

        public async Task<HarvestSellingPriceViewModel> UpdateHarvestSellingPrice(Guid id, UpdateHarvestSellingPriceRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var harvestSellingPriceInRequest = mapper.Map<HarvestSellingPrice>(request);
            var harvestSellingPrice = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (harvestSellingPrice == null)
            {
                return null;
            }
            harvestSellingPrice.Price = harvestSellingPriceInRequest.Price;
            harvestSellingPrice.HarvestSellingId = harvestSellingPriceInRequest.HarvestSellingId;
            harvestSellingPrice.Status = harvestSellingPriceInRequest.Status;
            await UpdateAsyn(harvestSellingPrice);
            return mapper.Map<HarvestSellingPriceViewModel>(harvestSellingPrice);
        }

        public async Task<int> DeleteHarvestSellingPrice(Guid id)
        {
            var harvestSellingPrice = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (harvestSellingPrice == null)
            {
                return 0;
            }
            await UpdateAsyn(harvestSellingPrice);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
