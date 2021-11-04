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

namespace VuonDau.Business.Services
{
    public partial interface IHarvestSellingPriceService
    {
        Task<List<HarvestSellingPriceViewModel>> GetAllHarvestSellingPrices(HarvestSellingPriceViewModel filter);
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

        public async Task<List<HarvestSellingPriceViewModel>> GetAllHarvestSellingPrices(HarvestSellingPriceViewModel filter)
        {
            return await Get().ProjectTo<HarvestSellingPriceViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
        }

        public async Task<HarvestSellingPriceViewModel> GetHarvestSellingPriceById(Guid id)
        {
            return await Get(p => p.Id == id).ProjectTo<HarvestSellingPriceViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<List<HarvestSellingPriceViewModel>> GetHarvestSellingPriceByHarvestSellingId(Guid HarvestSellingId)
        {
            return await Get(p => p.HarvestSellingId == HarvestSellingId).ProjectTo<HarvestSellingPriceViewModel>(_mapper).ToListAsync();
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
