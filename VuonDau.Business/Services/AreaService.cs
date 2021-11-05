using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Area;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using VuonDau.Business.Requests;
using Microsoft.Extensions.Configuration;
using FirebaseAdmin.Auth;
using VuonDau.Data.Common.Constants;
using Reso.Core.Utilities;

namespace VuonDau.Business.Services
{
    public partial interface IAreaService
    {
        Task<List<AreaViewModel>> GetAllAreas(string name);
        Task<AreaViewModel> GetAreaById(Guid id);
        Task<AreaViewModel> CreateArea(CreateAreaRequest request);
        Task<AreaViewModel> UpdateArea(Guid id, UpdateAreaRequest request);
        Task<int> DeleteArea(Guid id);
    }


    public partial class AreaService
    {
        private readonly AutoMapper.IConfigurationProvider _mapper;

        public AreaService(IUnitOfWork unitOfWork, IAreaRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<AreaViewModel>> GetAllAreas(string name)
        {
            name = name == null ? "" : name;
            return await Get(a => a.Name.Contains(name)).ProjectTo<AreaViewModel>(_mapper).ToListAsync();
        }

        public async Task<AreaViewModel> GetAreaById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<AreaViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<AreaViewModel> CreateArea(CreateAreaRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var area = mapper.Map<Area>(request);
            await CreateAsyn(area);
            var areaViewModel = mapper.Map<AreaViewModel>(area);
            return areaViewModel;
        }

        public async Task<AreaViewModel> UpdateArea(Guid id, UpdateAreaRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var areaInRequest = mapper.Map<Area>(request);
            var area = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (area == null)
            {
                return null;
            }
            area.Name = areaInRequest.Name;
            area.Description = areaInRequest.Description;
            await UpdateAsyn(area);
            return mapper.Map<AreaViewModel>(area);
        }

        public async Task<int> DeleteArea(Guid id)
        {
            var area = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (area == null)
            {
                return 0;
            }

            await UpdateAsyn(area);

            return 1;
        }

        //public override bool Equals(object obj)
        //{
        //    return obj is AreaService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
