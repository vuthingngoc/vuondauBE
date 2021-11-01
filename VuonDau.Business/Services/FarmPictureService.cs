using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.FarmPicture;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Reso.Core.Utilities;

namespace VuonDau.Business.Services
{
    public partial interface IFarmPictureService
    {
        Task<List<FarmPictureViewModel>> GetAllFarmPictures(FarmPictureViewModel filter);
        Task<List<FarmPictureViewModel>> GetFarmPictureById(Guid id);
        Task<FarmPictureViewModel> CreateFarmPicture(CreateFarmPictureRequest request);
        Task<FarmPictureViewModel> UpdateFarmPicture(Guid id, UpdateFarmPictureRequest request);
        Task<int> DeleteFarmPicture(Guid id);
    }


    public partial class FarmPictureService 
    {
        private readonly IConfigurationProvider _mapper;

        public FarmPictureService(IUnitOfWork unitOfWork, IFarmPictureRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<FarmPictureViewModel>> GetAllFarmPictures(FarmPictureViewModel filter)
        {
            return await Get().ProjectTo<FarmPictureViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
        }

        public async Task<List<FarmPictureViewModel>> GetFarmPictureById(Guid id)
        {
            return await Get(p => p.FarmId == id).ProjectTo<FarmPictureViewModel>(_mapper).ToListAsync();
        }

        public async Task<FarmPictureViewModel> CreateFarmPicture(CreateFarmPictureRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var farmPicture = mapper.Map<FarmPicture>(request);
            await CreateAsyn(farmPicture);
            var farmPictureViewModel = mapper.Map<FarmPictureViewModel>(farmPicture);
            return farmPictureViewModel;
        }

        public async Task<FarmPictureViewModel> UpdateFarmPicture(Guid id, UpdateFarmPictureRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var farmPictureInRequest = mapper.Map<FarmPicture>(request);
            var farmPicture = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (farmPicture == null)
            {
                return null;
            }
            farmPicture.FarmId = farmPictureInRequest.FarmId;
            farmPicture.Src = farmPictureInRequest.Src;
            farmPicture.Alt = farmPictureInRequest.Alt;
            await UpdateAsyn(farmPicture);
            return mapper.Map<FarmPictureViewModel>(farmPicture);
        }

        public async Task<int> DeleteFarmPicture(Guid id)
        {
            var farmPicture = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (farmPicture == null)
            {
                return 0;
            }
            await UpdateAsyn(farmPicture);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmPictureerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
