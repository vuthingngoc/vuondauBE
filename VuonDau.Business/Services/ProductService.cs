using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Product;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Reso.Core.Utilities;

namespace VuonDau.Business.Services
{
    public partial interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProducts(ProductViewModel filter);
        Task<ProductViewModel> GetProductById(Guid id);
        Task<List<ProductViewModel>> GetProductByType(Guid id);
        Task<ProductViewModel> CreateProduct(CreateProductRequest request);
        Task<ProductViewModel> UpdateProduct(Guid id, UpdateProductRequest request);
        Task<int> DeleteProduct(Guid id);
    }


    public partial class ProductService
    {
        private readonly IConfigurationProvider _mapper;


        public ProductService(IUnitOfWork unitOfWork, IProductRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }
        public async Task<List<ProductViewModel>> GetAllProducts(ProductViewModel filter)
        {
            return await Get().ProjectTo<ProductViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
        }
        public async Task<ProductViewModel> GetProductById(Guid id)
        {
            return await Get(p => p.Id == id).ProjectTo<ProductViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<List<ProductViewModel>> GetProductByType(Guid ProductTypeId)
        {
            return await Get(p => p.ProductTypeId == ProductTypeId).ProjectTo<ProductViewModel>(_mapper).ToListAsync();
        }
        public async Task<ProductViewModel> CreateProduct(CreateProductRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var product = mapper.Map<Product>(request);
            product.Status = (int)Status.Active;
            product.DataOfCreate = DateTime.UtcNow;
            await CreateAsyn(product);
            var productViewModel = mapper.Map<ProductViewModel>(product);
            return productViewModel;
        }
        public async Task<ProductViewModel> UpdateProduct(Guid id, UpdateProductRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var productInRequest = mapper.Map<Product>(request);
            var product = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return null;
            }
            product.ProductTypeId = productInRequest.ProductTypeId;
            product.Name = productInRequest.Name;
            product.Description = productInRequest.Description;
            product.Status = 1;
            await UpdateAsyn(product);
            return mapper.Map<ProductViewModel>(product);
        }
        public async Task<int> DeleteProduct(Guid id)
        {
            var product = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return 0;
            }

            product.Status = (int)Status.Inactive;
            await UpdateAsyn(product);

            return 1;
        }
        public override bool Equals(object obj)
        {
            return obj is ProductService service &&
                   EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        }
    }
}
