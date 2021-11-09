using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.FarmType;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Reso.Core.Utilities;

namespace VuonDau.Business.Services
{
    public partial interface IFarmTypeService
    {
        Task<List<FarmTypeViewModel>> GetAllFarmTypes(string name);
        Task<FarmTypeViewModel> GetFarmTypeById(Guid id);
        Task<FarmTypeViewModel> CreateFarmType(CreateFarmTypeRequest request);
        Task<FarmTypeViewModel> UpdateFarmType(Guid id, UpdateFarmTypeRequest request);
        Task<int> DeleteFarmType(Guid id);
    }


    public partial class FarmTypeService
    {
        private readonly IConfigurationProvider _mapper;

        public FarmTypeService(IUnitOfWork unitOfWork, IFarmTypeRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<FarmTypeViewModel>> GetAllFarmTypes(string name)
        {
            name = name == null ? "" : name;
            return await Get(f => f.Name.Contains(name)).ProjectTo<FarmTypeViewModel>(_mapper).ToListAsync();
        }

        public async Task<FarmTypeViewModel> GetFarmTypeById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<FarmTypeViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<FarmTypeViewModel> CreateFarmType(CreateFarmTypeRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var farmType = mapper.Map<FarmType>(request);
            await CreateAsyn(farmType);
            var farmTypeViewModel = mapper.Map<FarmTypeViewModel>(farmType);
            return farmTypeViewModel;
        }

        public async Task<FarmTypeViewModel> UpdateFarmType(Guid id, UpdateFarmTypeRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var farmTypeInRequest = mapper.Map<FarmType>(request);
            var farmType = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (farmType == null)
            {
                return null;
            }
            farmType.Name = farmTypeInRequest.Name;
            farmType.Description = farmTypeInRequest.Description;
            await UpdateAsyn(farmType);
            return mapper.Map<FarmTypeViewModel>(farmType);
        }

        public async Task<int> DeleteFarmType(Guid id)
        {
            var farmType = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (farmType == null)
            {
                return 0;
            }

            //farm.Status = (int)Status.Inactive;
            await UpdateAsyn(farmType);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
