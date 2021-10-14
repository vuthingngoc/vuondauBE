using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.ProductPicture;
using AutoMapper.QueryableExtensions;
using AutoMapper;
namespace VuonDau.Business.Services
{
    public partial interface IProductPictureService
    {
        Task<List<ProductPictureViewModel>> GetAllProductPictures();
        Task<ProductPictureViewModel> GetProductPictureById(Guid id);
        Task<ProductPictureViewModel> CreateProductPicture(CreateProductPictureRequest request);
        Task<ProductPictureViewModel> UpdateProductPicture(Guid id, UpdateProductPictureRequest request);
        Task<int> DeleteProductPicture(Guid id);
    }


    public partial class ProductPictureService 
    {
        private readonly IConfigurationProvider _mapper;

        public ProductPictureService(IUnitOfWork unitOfWork, IProductPictureRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<ProductPictureViewModel>> GetAllProductPictures()
        {
            return await Get().ProjectTo<ProductPictureViewModel>(_mapper).ToListAsync();
        }

        public async Task<ProductPictureViewModel> GetProductPictureById(Guid id)
        {
            return await Get(p => p.Id == id).ProjectTo<ProductPictureViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<ProductPictureViewModel> CreateProductPicture(CreateProductPictureRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var productPicture = mapper.Map<ProductPicture>(request);
            await CreateAsyn(productPicture);
            var productPictureViewModel = mapper.Map<ProductPictureViewModel>(productPicture);
            return productPictureViewModel;
        }

        public async Task<ProductPictureViewModel> UpdateProductPicture(Guid id, UpdateProductPictureRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var productPictureInRequest = mapper.Map<ProductPicture>(request);
            var productPicture = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (productPicture == null)
            {
                return null;
            }
            productPicture.ProductId = productPictureInRequest.ProductId;
            productPicture.Src = productPictureInRequest.Src;
            productPicture.Alt = productPictureInRequest.Alt;
            await UpdateAsyn(productPicture);
            return mapper.Map<ProductPictureViewModel>(productPicture);
        }

        public async Task<int> DeleteProductPicture(Guid id)
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
        //    return obj is ProductPictureerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
