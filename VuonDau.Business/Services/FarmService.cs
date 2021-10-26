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
        Task<List<FarmViewModel>> GetAllFarms();
        Task<FarmViewModel> GetFarmById(Guid id);
        Task<List<FarmViewModel>> GetFarmByType(Guid id);
        Task<FarmViewModel> CreateFarm(CreateFarmRequest request);
        Task<FarmViewModel> UpdateFarm(Guid id, UpdateFarmRequest request);
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

        public async Task<List<FarmViewModel>> GetAllFarms()
        {
            return await Get().ProjectTo<FarmViewModel>(_mapper).ToListAsync();
        }

        public async Task<FarmViewModel> GetFarmById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<FarmViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<List<FarmViewModel>> GetFarmByType(Guid FarmTypeId)
        {
            return await Get(p => p.FarmTypeId == FarmTypeId).ProjectTo<FarmViewModel>(_mapper).ToListAsync();
        }
        public async Task<FarmViewModel> CreateFarm(CreateFarmRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var farm = mapper.Map<Farm>(request);
            farm.Status = (int)FarmerStatus.Active;
            farm.DateOfCreate = DateTime.UtcNow;
            await CreateAsyn(farm);
            var farmViewModel = mapper.Map<FarmViewModel>(farm);
            return farmViewModel;
        }

        public async Task<FarmViewModel> UpdateFarm(Guid id, UpdateFarmRequest request)
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
            farm.AreaId = farmInRequest.AreaId;
            farm.Address = farmInRequest.Address;
            farm.Description = farmInRequest.Description;
            farm.DateUpdate = DateTime.UtcNow;
            farm.Status = 1;
            await UpdateAsyn(farm);
            return mapper.Map<FarmViewModel>(farm);
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
