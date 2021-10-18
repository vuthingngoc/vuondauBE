using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Farm;
using AutoMapper.QueryableExtensions;
using AutoMapper;
namespace VuonDau.Business.Services
{
    public partial interface IFarmService
    {
        Task<List<FarmFullViewModel>> GetAllFarms();
        Task<FarmFullViewModel> GetFarmById(Guid id);
        Task<FarmFullViewModel> CreateFarm(CreateFarmRequest request);
        Task<FarmFullViewModel> UpdateFarm(Guid id, UpdateFarmRequest request);
        Task<int> DeleteFarm(Guid id);
    }


    public partial class FarmService 
    {
        private readonly IConfigurationProvider _mapper;

        public FarmService(IUnitOfWork unitOfWork, IFarmRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<FarmFullViewModel>> GetAllFarms()
        {
            return await Get().ProjectTo<FarmFullViewModel>(_mapper).ToListAsync();
        }

        public async Task<FarmFullViewModel> GetFarmById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<FarmFullViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<FarmFullViewModel> CreateFarm(CreateFarmRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var farm = mapper.Map<Farm>(request);
            farm.Status = (int)FarmerStatus.Active;
            farm.DateOfCreate = DateTime.UtcNow;
            await CreateAsyn(farm);
            var farmViewModel = mapper.Map<FarmFullViewModel>(farm);
            return farmViewModel;
        }

        public async Task<FarmFullViewModel> UpdateFarm(Guid id, UpdateFarmRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var farmInRequest = mapper.Map<Farm>(request);
            var farm = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (farm == null)
            {
                return null;
            }
            farm.FarmTypeId = farmInRequest.FarmTypeId;
            farm.FarmerId = farmInRequest.FarmerId;
            farm.Name = farmInRequest.Name;
            farm.Address = farmInRequest.Address;
            farm.Description = farmInRequest.Description;
            farm.DateUpdate = DateTime.UtcNow;
            farm.Status = farmInRequest.Status;
            await UpdateAsyn(farm);
            return mapper.Map<FarmFullViewModel>(farm);
        }

        public async Task<int> DeleteFarm(Guid id)
        {
            var farm = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (farm == null)
            {
                return 0;
            }
            farm.Status = (int)Status.Inactive;
            await UpdateAsyn(farm);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
