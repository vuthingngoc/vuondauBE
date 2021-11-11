using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using VuonDau.Business.Requests.ProductInCart;
using Reso.Core.Utilities;
using System.Linq;

namespace VuonDau.Business.Services
{
    public partial interface IProductInCartService
    {
        Task<List<ProductInCartViewModel>> GetAllProductInCarts(ProductInCartViewModel filter);
        Task<ProductInCartViewModel> GetProductInCartById(Guid id);
        Task<List<ProductInCartViewModel>> GetProductInCartByCustomerId(Guid id);
        Task<List<ProductInCartViewModel>> GetProductInCartByHarvestSellingId(Guid id);
        Task<ProductInCartViewModel> CreateProductInCart(CreateProductInCartRequest request);
        Task<ProductInCartViewModel> UpdateProductInCart(Guid id, UpdateProductInCartRequest request);
        Task<ProductInCartViewModel> UpdateExisted(ProductInCart productInCart, CreateProductInCartRequest request);
        Task<int> DeleteProductInCart(Guid id);
    }


    public partial class ProductInCartService
    {
        private readonly IConfigurationProvider _mapper;

        public ProductInCartService(IUnitOfWork unitOfWork, IProductInCartRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<ProductInCartViewModel>> GetAllProductInCarts(ProductInCartViewModel filter)
        {
            return await Get().ProjectTo<ProductInCartViewModel>(_mapper).OrderBy(p => p.Quantity).OrderByDescending(p => p.Status).DynamicFilter(filter).ToListAsync();
        }

        public async Task<ProductInCartViewModel> GetProductInCartById(Guid id)
        {
            return await Get(p => p.Id == id && p.Status == (int)Status.Active).OrderBy(p => p.Quantity).OrderByDescending(p => p.Status).ProjectTo<ProductInCartViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<List<ProductInCartViewModel>> GetProductInCartByCustomerId(Guid CustomerId)
        {
            return await Get(p => p.CustomerId == CustomerId).OrderBy(p => p.Quantity).OrderByDescending(p => p.Status).ProjectTo<ProductInCartViewModel>(_mapper).ToListAsync();
        }
        public async Task<List<ProductInCartViewModel>> GetProductInCartByHarvestSellingId(Guid HarvestSellingId)
        {
            return await Get(p => p.HarvestSellingId == HarvestSellingId).OrderBy(p => p.Quantity).OrderByDescending(p => p.Status).ProjectTo<ProductInCartViewModel>(_mapper).ToListAsync();
        }
        public async Task<ProductInCartViewModel> CreateProductInCart(CreateProductInCartRequest request)
        {
            var productExisted = await Get(p => p.HarvestSellingId == request.HarvestSellingId && p.Status == (int)Status.Active && p.CustomerId == request.CustomerId)
                .FirstOrDefaultAsync();
            if (productExisted != null)
            {
                var mapper2 = _mapper.CreateMapper();
                var productInCartViewModel2 = await UpdateExisted(productExisted, request);
                var productInCartViewMode2l = mapper2.Map<ProductInCartViewModel>(productExisted);
                return productInCartViewModel2;
            }
            else
            {
                var mapper = _mapper.CreateMapper();
                var productInCart = mapper.Map<ProductInCart>(request);
                productInCart.Status = (int)Status.Active;
                await CreateAsyn(productInCart);
                var productInCartViewModel = mapper.Map<ProductInCartViewModel>(productInCart);
                return productInCartViewModel;
            }
        }

        public async Task<ProductInCartViewModel> UpdateProductInCart(Guid id, UpdateProductInCartRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var productInCartRequest = mapper.Map<ProductInCart>(request);
            var productInCart = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (productInCart == null)
            {
                return null;
            }
            productInCart.CustomerId = productInCartRequest.CustomerId;
            productInCart.HarvestSellingId = productInCartRequest.HarvestSellingId;
            productInCart.Quantity = productInCartRequest.Quantity;
            productInCart.Price = productInCartRequest.Price;
            productInCart.Status = productInCartRequest.Status;
            await UpdateAsyn(productInCart);
            return mapper.Map<ProductInCartViewModel>(productInCart);
        }
        public async Task<ProductInCartViewModel> UpdateExisted(ProductInCart productInCart, CreateProductInCartRequest request)
        {
            var mapper = _mapper.CreateMapper();
            productInCart.Quantity += request.Quantity;
            productInCart.Price = productInCart.Price;
            await UpdateAsyn(productInCart);
            return mapper.Map<ProductInCartViewModel>(productInCart);
        }

        public async Task<int> DeleteProductInCart(Guid id)
        {
            var productInCart = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (productInCart == null)
            {
                return 0;
            }
            await DeleteAsyn(productInCart);
            return 1;
        }
    }
}
