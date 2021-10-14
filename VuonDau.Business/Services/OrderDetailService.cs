using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.OrderDetail;
using AutoMapper.QueryableExtensions;
using AutoMapper;
namespace VuonDau.Business.Services
{
    public partial interface IOrderDetailService
    {
        Task<List<OrderDetailViewModel>> GetAllOrderDetails();
        Task<OrderDetailViewModel> GetOrderDetailById(Guid id);
        Task<OrderDetailViewModel> CreateOrderDetail(CreateOrderDetailRequest request);
        Task<OrderDetailViewModel> UpdateOrderDetail(Guid id, UpdateOrderDetailRequest request);
        Task<int> DeleteOrderDetail(Guid id);
    }


    public partial class OrderDetailService
    {
        private readonly IConfigurationProvider _mapper;

        public OrderDetailService(IUnitOfWork unitOfWork, IOrderDetailRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<OrderDetailViewModel>> GetAllOrderDetails()
        {
            return await Get(p => p.Status == (int)Status.Active).ProjectTo<OrderDetailViewModel>(_mapper).ToListAsync();
        }

        public async Task<OrderDetailViewModel> GetOrderDetailById(Guid id)
        {
            return await Get(p => p.Id == id && p.Status == (int)Status.Active).ProjectTo<OrderDetailViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<OrderDetailViewModel> CreateOrderDetail(CreateOrderDetailRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var orderDetail = mapper.Map<OrderDetail>(request);
            orderDetail.Status = (int)Status.Active;
            await CreateAsyn(orderDetail);
            var orderDetailViewModel = mapper.Map<OrderDetailViewModel>(orderDetail);
            return orderDetailViewModel;
        }

        public async Task<OrderDetailViewModel> UpdateOrderDetail(Guid id, UpdateOrderDetailRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var orderDetailInRequest = mapper.Map<OrderDetail>(request);
            var orderDetail = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (orderDetail == null)
            {
                return null;
            }
            orderDetail.ProductId = orderDetailInRequest.ProductId;
            orderDetail.OrderId = orderDetailInRequest.OrderId;
            orderDetail.Weight = orderDetailInRequest.Weight;
            orderDetail.Price = orderDetailInRequest.Price;
            orderDetail.Status = 1;
            await UpdateAsyn(orderDetail);
            return mapper.Map<OrderDetailViewModel>(orderDetail);
        }

        public async Task<int> DeleteOrderDetail(Guid id)
        {
            var orderDetail = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (orderDetail == null)
            {
                return 0;
            }

            orderDetail.Status = (int)Status.Inactive;
            await UpdateAsyn(orderDetail);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
