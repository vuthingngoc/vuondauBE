using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Order;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Reso.Core.Utilities;
using VuonDau.Business.Requests.OrderDetail;
using System.Linq;

namespace VuonDau.Business.Services
{
    public partial interface IOrderService
    {
        Task<List<OrderViewModel>> GetAllOrders(SearchOrderRequest request);
        Task<OrderViewModel> GetOrderById(Guid id);
        Task<List<OrderViewModel>> GetOrderByCustomerId(Guid id);
        Task<OrderViewModel> CreateOrder(CreateOrderRequest request);
        Task<OrderViewModel> UpdateOrder(Guid id, UpdateOrderRequest request);
        Task<OrderViewModel> UpdateStatusOrder(Guid id, UpdateOrderStatusRequest request);
        Task<int> DeleteOrder(Guid id);
    }


    public partial class OrderService
    {
        private readonly IConfigurationProvider _mapper;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IProductInCartService _productInCartService;

        public OrderService(IUnitOfWork unitOfWork, IOrderRepository repository, IMapper mapper, IOrderDetailService orderDetailService, IProductInCartService productInCartService) : base(unitOfWork,
            repository)
        {
            _orderDetailService = orderDetailService;
            _productInCartService = productInCartService;
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<OrderViewModel>> GetAllOrders(SearchOrderRequest request)
        {
            if (request.Status == null)
            {
                if(request.CustomerId == null)
                {
                    if (request.StartDate == null && request.EndDate == null)
                    {
                        OrderViewModel filter = new OrderViewModel();
                        return await Get().OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
                    }
                    if (request.EndDate == null)
                    {
                        return await Get(o => o.DateOfCreate >= request.StartDate)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                    }
                    if (request.StartDate == null)
                    {
                        return await Get(o => o.DateOfCreate <= request.EndDate)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                    }
                    return await Get(o => request.StartDate <= o.DateOfCreate && o.DateOfCreate <= request.EndDate)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                } else
                {
                    if (request.StartDate == null && request.EndDate == null)
                    {
                        return await Get(o => o.CustomerId == request.CustomerId)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                    }
                    if (request.EndDate == null)
                    {
                        return await Get(o => o.DateOfCreate >= request.StartDate && o.CustomerId == request.CustomerId)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                    }
                    if (request.StartDate == null)
                    {
                        return await Get(o => o.DateOfCreate <= request.EndDate && o.CustomerId == request.CustomerId)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                    }
                    return await Get(o => request.StartDate <= o.DateOfCreate && o.DateOfCreate <= request.EndDate && o.CustomerId == request.CustomerId)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                }
                
            }
            else
            { 
                if(request.CustomerId == null)
                {
                    if (request.StartDate == null && request.EndDate == null)
                    {
                        OrderViewModel filter = new OrderViewModel();
                        return await Get(o => o.Status == request.Status).OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
                    }
                    if (request.EndDate == null)
                    {
                        return await Get(o => o.DateOfCreate >= request.StartDate && o.Status == request.Status)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                    }
                    if (request.StartDate == null)
                    {
                        return await Get(o => o.DateOfCreate <= request.EndDate && o.Status == request.Status)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                    }
                    return await Get(o => request.StartDate <= o.DateOfCreate && o.DateOfCreate <= request.EndDate && o.Status == request.Status)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                } else
                {
                    if (request.StartDate == null && request.EndDate == null)
                    {
                        return await Get(o => o.CustomerId == request.CustomerId && o.Status == request.Status)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                    }
                    if (request.EndDate == null)
                    {
                        return await Get(o => o.DateOfCreate >= request.StartDate && o.Status == request.Status && o.CustomerId == request.CustomerId)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                    }
                    if (request.StartDate == null)
                    {
                        return await Get(o => o.DateOfCreate <= request.EndDate && o.Status == request.Status && o.CustomerId == request.CustomerId)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                    }
                    return await Get(o => request.StartDate <= o.DateOfCreate && o.DateOfCreate <= request.EndDate && o.Status == request.Status && o.CustomerId == request.CustomerId)
                    .OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
                }
            }
        }
        public async Task<OrderViewModel> GetOrderById(Guid id)
        {
            return await Get(p => p.Id == id && p.Status == (int)Status.Active).OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<List<OrderViewModel>> GetOrderByCustomerId(Guid CustomerId)
        {
            return await Get(p => p.CustomerId == CustomerId).OrderByDescending(o => o.Status).OrderBy(o => o.DateOfCreate).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
        }
        public async Task<OrderViewModel> CreateOrder(CreateOrderRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var order = mapper.Map<Order>(request);
            order.Status = (int)Status.Active;
            order.DateOfCreate = DateTime.UtcNow;
            await CreateAsyn(order);
            var orderViewModel = mapper.Map<OrderViewModel>(order);
            if(orderViewModel != null)
            {
                ProductInCartViewModel filter = new ProductInCartViewModel();
                List<ProductInCartViewModel> products = await _productInCartService.GetAllProductInCarts(filter);
                double? totalPrice = 0;
                if (products != null)
                {
                    CreateOrderDetailRequest req = new CreateOrderDetailRequest();
                    foreach(ProductInCartViewModel product in products)
                    {
                        req.OrderId = orderViewModel.Id;
                        req.HarvestsellingId = product.HarvestSelling.Id;
                        req.Weight = product.Quantity;
                        req.Price = product.Price;
                        var orderDetail = await _orderDetailService.CreateOrderDetail(req);
                        totalPrice += product.Price;
                    }
                    orderViewModel.TotalPrice = totalPrice;
                }
            }
            return orderViewModel;
        }

        public async Task<OrderViewModel> UpdateOrder(Guid id, UpdateOrderRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var orderInRequest = mapper.Map<Order>(request);
            var order = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (order == null)
            {
                return null;
            }
            order.CustomerId = orderInRequest.CustomerId;
            order.CampaignId = orderInRequest.CampaignId;
            order.FullName = orderInRequest.FullName;
            order.Message = orderInRequest.Message;
            order.Phone = orderInRequest.Phone;
            order.Address = orderInRequest.Address;
            order.TotalPrice = orderInRequest.TotalPrice;
            order.Status = orderInRequest.Status;
            await UpdateAsyn(order);
            return mapper.Map<OrderViewModel>(order);
        }
        public async Task<OrderViewModel> UpdateStatusOrder(Guid id, UpdateOrderStatusRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var order = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (order == null)
            {
                return null;
            }
            order.Status = request.Status;
            await UpdateAsyn(order);
            return mapper.Map<OrderViewModel>(order);
        }

        public async Task<int> DeleteOrder(Guid id)
        {
            var order = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (order == null)
            {
                return 0;
            }

            order.Status = (int)Status.Inactive;
            await UpdateAsyn(order);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
