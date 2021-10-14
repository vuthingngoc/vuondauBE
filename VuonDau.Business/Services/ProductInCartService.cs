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

namespace VuonDau.Business.Services
{
    public partial interface IProductInCartService
    {
        Task<List<ProductInCartViewModel>> GetAllProductInCarts();
        Task<ProductInCartViewModel> GetProductInCartById(Guid id);
        Task<ProductInCartViewModel> CreateProductInCart(CreateProductInCartRequest request);
        Task<ProductInCartViewModel> UpdateProductInCart(Guid id, UpdateProductInCartRequest request);
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

        public async Task<List<ProductInCartViewModel>> GetAllProductInCarts()
        {
            return await Get(p => p.Status == (int)ProductInCartStatus.Active).ProjectTo<ProductInCartViewModel>(_mapper).ToListAsync();
        }

        public async Task<ProductInCartViewModel> GetProductInCartById(Guid id)
        {
            return await Get(p => p.Id == id && p.Status == (int)ProductInCartStatus.Active).ProjectTo<ProductInCartViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<ProductInCartViewModel> CreateProductInCart(CreateProductInCartRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var productInCart = mapper.Map<ProductInCart>(request);
            productInCart.Status = (int)ProductInCartStatus.Active;
            await CreateAsyn(productInCart);
            var productInCartViewModel = mapper.Map<ProductInCartViewModel>(productInCart);
            return productInCartViewModel;
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
            productInCart.ProductId = productInCartRequest.ProductId;
            productInCart.Status = productInCartRequest.Status;
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

            productInCart.Status = (int)ProductInCartStatus.Inactive;
            await UpdateAsyn(productInCart);

            return 1;
        }
    }
}
