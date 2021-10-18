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
namespace VuonDau.Business.Services
{
    public partial interface IProductService
    {
        Task<List<ProductFullViewModel>> GetAllProducts();
        Task<ProductFullViewModel> GetProductById(Guid id);
        Task<ProductFullViewModel> CreateProduct(CreateProductRequest request);
        Task<ProductFullViewModel> UpdateProduct(Guid id, UpdateProductRequest request);
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
        public async Task<List<ProductFullViewModel>> GetAllProducts()
        {
            return await Get().ProjectTo<ProductFullViewModel>(_mapper).ToListAsync();
        }
        public async Task<ProductFullViewModel> GetProductById(Guid id)
        {
            return await Get(p => p.Id == id).ProjectTo<ProductFullViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<ProductFullViewModel> CreateProduct(CreateProductRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var product = mapper.Map<Product>(request);
            product.Status = (int)ProductStatus.Active;
            product.DataOfCreate = DateTime.UtcNow;
            await CreateAsyn(product);
            var productViewModel = mapper.Map<ProductFullViewModel>(product);
            return productViewModel;
        }
        public async Task<ProductFullViewModel> UpdateProduct(Guid id, UpdateProductRequest request)
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
            product.Status = productInRequest.Status;
            await UpdateAsyn(product);
            return mapper.Map<ProductFullViewModel>(product);
        }
        public async Task<int> DeleteProduct(Guid id)
        {
            var product = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return 0;
            }

            product.Status = (int)ProductStatus.Inactive;
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