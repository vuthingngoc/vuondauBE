/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////
namespace VuonDau.Business.Gens.Services
{
    using Reso.Core.BaseConnect;
    using VuonDau.Data.Repositories;
    using VuonDau.Data.Models;
    using System.Collections.Generic;
    using VuonDau.Data.Common.Enum;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using VuonDau.Business.ViewModel;
    using System;
    using VuonDau.Business.Requests;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;

    public partial interface IFarmerService
    {
        Task<List<FarmerViewModel>> GetAllFarmers();
        Task<FarmerViewModel> GetFarmerById(int id);
        Task<FarmerViewModel> CreateFarmer(CreateFarmerRequest request);
        Task<FarmerViewModel> UpdateFarmer(int id, UpdateFarmerRequest request);
        Task<int> DeleteFarmer(int id);
    }
    //public partial interface IFarmerService : IBaseService<Farmer>
    //{
    //}

    public partial class FarmerService : BaseService<Farmer>, IFarmerService
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

        public async Task<FarmerViewModel> GetFarmerById(int id)
        {
            return await Get(p => p.Id == id && p.Status == (int)FarmerStatus.Active).ProjectTo<FarmerViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<FarmerViewModel> CreateFarmer(CreateFarmerRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var farmer = mapper.Map<Farmer>(request);
            var a = request.BirthDay;
            var b = request.FirstName;
            var c = request.LastName;
            var d = request.Phone;
            farmer.Status = (int)FarmerStatus.Active;
            farmer.DateOfCreate = DateTime.UtcNow;
            await CreateAsyn(farmer);
            var farmerViewModel = mapper.Map<FarmerViewModel>(farmer);
            return farmerViewModel;
        }

        public async Task<FarmerViewModel> UpdateFarmer(int id, UpdateFarmerRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var farmerInRequest = mapper.Map<Farmer>(request);
            var farmer = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (farmer == null)
            {
                return null;
            }

            farmer.Email = farmerInRequest.Email;
            farmer.FirstName = farmerInRequest.FirstName;
            farmer.LastName = farmerInRequest.LastName;
            farmer.Password = farmerInRequest.Password;
            farmer.Phone = farmerInRequest.Phone;
            farmer.BirthDay = farmerInRequest.BirthDay;
            farmer.Gender = farmerInRequest.Gender;
            farmer.Status = (int)FarmerStatus.Active;
            DateTime dateTime = new DateTime();
            farmer.DateOfCreate = dateTime;
            await UpdateAsyn(farmer);
            return mapper.Map<FarmerViewModel>(farmer);
        }

        public async Task<int> DeleteFarmer(int id)
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
    }
}
