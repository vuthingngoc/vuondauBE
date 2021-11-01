using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.ProductType;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Reso.Core.Utilities;

namespace VuonDau.Business.Services
{
    public partial interface IProductTypeService
    {
        Task<List<ProductTypeViewModel>> GetAllProductTypes(ProductTypeViewModel filter);
        Task<ProductTypeViewModel> GetProductTypeById(Guid id);
        Task<ProductTypeViewModel> CreateProductType(CreateProductTypeRequest request);
        Task<ProductTypeViewModel> UpdateProductType(Guid id, UpdateProductTypeRequest request);
        Task<int> DeleteProductType(Guid id);
    }


    public partial class ProductTypeService
    {
        private readonly IConfigurationProvider _mapper;

        public ProductTypeService(IUnitOfWork unitOfWork, IProductTypeRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<ProductTypeViewModel>> GetAllProductTypes(ProductTypeViewModel filter)
        {
            return await Get().ProjectTo<ProductTypeViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
        }

        public async Task<ProductTypeViewModel> GetProductTypeById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<ProductTypeViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<ProductTypeViewModel> CreateProductType(CreateProductTypeRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var productType = mapper.Map<ProductType>(request);
            await CreateAsyn(productType);
            var productTypeViewModel = mapper.Map<ProductTypeViewModel>(productType);
            return productTypeViewModel;
        }

        public async Task<ProductTypeViewModel> UpdateProductType(Guid id, UpdateProductTypeRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var productTypeInRequest = mapper.Map<ProductType>(request);
            var productType = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (productType == null)
            {
                return null;
            }
            productType.Name = productTypeInRequest.Name;
            productType.Description = productTypeInRequest.Description;
            await UpdateAsyn(productType);
            return mapper.Map<ProductTypeViewModel>(productType);
        }

        public async Task<int> DeleteProductType(Guid id)
        {
            var productType = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (productType == null)
            {
                return 0;
            }

            //product.Status = (int)Status.Inactive;
            await UpdateAsyn(productType);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is ProductTypeService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
