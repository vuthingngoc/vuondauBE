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
using Reso.Core.Utilities;
using System.Linq;

namespace VuonDau.Business.Services
{
    public partial interface IFarmerService
    {
        Task<List<FarmerViewModel>> GetAllFarmers(FarmerViewModel filter);
        Task<FarmerViewModel> GetFarmerById(Guid id);
        Task<FarmerViewModel> CreateFarmer(CreateFarmerRequest request);
        Task<FarmerViewModel> UpdateFarmer(Guid id, UpdateFarmerRequest request);
        Task<FarmerViewModel> GetByMail(string mail);
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

        public async Task<List<FarmerViewModel>> GetAllFarmers(FarmerViewModel filter)
        {
            return await Get().OrderByDescending(s => s.Status).ProjectTo<FarmerViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
        }

        public async Task<FarmerViewModel> GetFarmerById(Guid id)
        {
            return await Get(p => p.Id == id).ProjectTo<FarmerViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<FarmerViewModel> GetByMail(string mail)
        {
            return await Get(c => c.Email.Equals(mail)).ProjectTo<FarmerViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<FarmerViewModel> CreateFarmer(CreateFarmerRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var farmer = mapper.Map<Farmer>(request);
            farmer.Status = (int)Status.Active;
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
            farmer.Status = 1;
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

            farmer.Status = (int)Status.Inactive;
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
