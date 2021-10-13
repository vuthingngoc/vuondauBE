using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Farmer;
using AutoMapper.QueryableExtensions;
using AutoMapper;
namespace VuonDau.Business.Services
{
    public partial interface IFarmerService
    {
        Task<List<FarmerViewModel>> GetAllFarmers();
        Task<FarmerViewModel> GetFarmerById(Guid id);
        Task<FarmerViewModel> CreateFarmer(CreateFarmerRequest request);
        Task<FarmerViewModel> UpdateFarmer(Guid id, UpdateFarmerRequest request);
        Task<int> DeleteFarmer(Guid id);
    }


    public partial class FarmerService 
    {
        private readonly IConfigurationProvider _mapper;

        public FarmerService(IUnitOfWork unitOfWork, IFarmerRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<FarmerViewModel>> GetAllFarmers()
        {
            return await Get(p => p.Status == (int)FarmerStatus.Active).ProjectTo<FarmerViewModel>(_mapper).ToListAsync();
        }

        public async Task<FarmerViewModel> GetFarmerById(Guid id)
        {
            return await Get(p => p.Id == id && p.Status == (int)FarmerStatus.Active).ProjectTo<FarmerViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<FarmerViewModel> CreateFarmer(CreateFarmerRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var farmer = mapper.Map<Farmer>(request);
            farmer.Status = (int)FarmerStatus.Active;
            farmer.DateOfCreate = DateTime.UtcNow;
            await CreateAsyn(farmer);
            var farmerViewModel = mapper.Map<FarmerViewModel>(farmer);
            return farmerViewModel;
        }

        public async Task<FarmerViewModel> UpdateFarmer(Guid id, UpdateFarmerRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var farmerInRequest = mapper.Map<Farmer>(request);
            var farmer = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (farmer == null)
            {
                return null;
            }
            farmer.FirstName = farmerInRequest.FirstName;
            farmer.LastName = farmerInRequest.LastName;
            farmer.Password = farmerInRequest.Password;
            farmer.Phone = farmerInRequest.Phone;
            farmer.BirthDay = farmerInRequest.BirthDay;
            farmer.Gender = farmerInRequest.Gender;
            farmer.Status = farmerInRequest.Status;
            await UpdateAsyn(farmer);
            return mapper.Map<FarmerViewModel>(farmer);
        }

        public async Task<int> DeleteFarmer(Guid id)
        {
            var farmer = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (farmer == null)
            {
                return 0;
            }

            farmer.Status = (int)FarmerStatus.Inactive;
            await UpdateAsyn(farmer);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
