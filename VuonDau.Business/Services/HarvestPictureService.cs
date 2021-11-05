using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.HarvestPicture;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Reso.Core.Utilities;

namespace VuonDau.Business.Services
{
    public partial interface IHarvestPictureService
    {
        Task<List<HarvestPictureViewModel>> GetAllHarvestPictures(HarvestPictureViewModel filter);
        Task<List<HarvestPictureViewModel>> GetHarvestPictureById(Guid id);
        Task<HarvestPictureViewModel> CreateHarvestPicture(CreateHarvestPictureRequest request);
        Task<HarvestPictureViewModel> UpdateHarvestPicture(Guid id, UpdateHarvestPictureRequest request);
        Task<int> DeleteHarvestPicture(Guid id);
    }


    public partial class HarvestPictureService 
    {
        private readonly IConfigurationProvider _mapper;

        public HarvestPictureService(IUnitOfWork unitOfWork, IHarvestPictureRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<HarvestPictureViewModel>> GetAllHarvestPictures(HarvestPictureViewModel filter)
        {
            return await Get().ProjectTo<HarvestPictureViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
        }

        public async Task<List<HarvestPictureViewModel>> GetHarvestPictureById(Guid id)
        {
            return await Get(p => p.HarvestId == id).ProjectTo<HarvestPictureViewModel>(_mapper).ToListAsync();
        }

        public async Task<HarvestPictureViewModel> CreateHarvestPicture(CreateHarvestPictureRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var productPicture = mapper.Map<HarvestPicture>(request);
            await CreateAsyn(productPicture);
            var productPictureViewModel = mapper.Map<HarvestPictureViewModel>(productPicture);
            return productPictureViewModel;
        }

        public async Task<HarvestPictureViewModel> UpdateHarvestPicture(Guid id, UpdateHarvestPictureRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var productPictureInRequest = mapper.Map<HarvestPicture>(request);
            var productPicture = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (productPicture == null)
            {
                return null;
            }
            productPicture.HarvestId = productPictureInRequest.HarvestId;
            productPicture.Src = productPictureInRequest.Src;
            productPicture.Alt = productPictureInRequest.Alt;
            await UpdateAsyn(productPicture);
            return mapper.Map<HarvestPictureViewModel>(productPicture);
        }

        public async Task<int> DeleteHarvestPicture(Guid id)
        {
            var productPicture = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (productPicture == null)
            {
                return 0;
            }
            await UpdateAsyn(productPicture);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is HarvestPictureerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
