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
namespace VuonDau.Business.Services
{
    public partial interface IOrderService
    {
        Task<List<OrderViewModel>> GetAllOrders();
        Task<OrderViewModel> GetOrderById(Guid id);
        Task<OrderViewModel> CreateOrder(CreateOrderRequest request);
        Task<OrderViewModel> UpdateOrder(Guid id, UpdateOrderRequest request);
        Task<int> DeleteOrder(Guid id);
    }


    public partial class OrderService
    {
        private readonly IConfigurationProvider _mapper;

        public OrderService(IUnitOfWork unitOfWork, IOrderRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<OrderViewModel>> GetAllOrders()
        {
            return await Get(p => p.Status == (int)Status.Active).ProjectTo<OrderViewModel>(_mapper).ToListAsync();
        }

        public async Task<OrderViewModel> GetOrderById(Guid id)
        {
            return await Get(p => p.Id == id && p.Status == (int)Status.Active).ProjectTo<OrderViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<OrderViewModel> CreateOrder(CreateOrderRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var order = mapper.Map<Order>(request);
            order.Status = (int)Status.Active;
            order.DateOfCreate = DateTime.UtcNow;
            await CreateAsyn(order);
            var orderViewModel = mapper.Map<OrderViewModel>(order);
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
            order.Address = orderInRequest.Address;
            order.TotalPrice = orderInRequest.TotalPrice;
            order.Status = 1;
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
