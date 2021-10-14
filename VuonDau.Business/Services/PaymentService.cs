using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Payment;
using AutoMapper.QueryableExtensions;
using AutoMapper;
namespace VuonDau.Business.Services
{
    public partial interface IPaymentService
    {
        Task<List<PaymentViewModel>> GetAllPayments();
        Task<PaymentViewModel> GetPaymentById(Guid id);
        Task<PaymentViewModel> CreatePayment(CreatePaymentRequest request);
        Task<PaymentViewModel> UpdatePayment(Guid id, UpdatePaymentRequest request);
        Task<int> DeletePayment(Guid id);
    }


    public partial class PaymentService
    {
        private readonly IConfigurationProvider _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IPaymentRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<PaymentViewModel>> GetAllPayments()
        {
            return await Get().ProjectTo<PaymentViewModel>(_mapper).ToListAsync();
        }

        public async Task<PaymentViewModel> GetPaymentById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<PaymentViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<PaymentViewModel> CreatePayment(CreatePaymentRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var payment = mapper.Map<Payment>(request);
            await CreateAsyn(payment);
            var paymentViewModel = mapper.Map<PaymentViewModel>(payment);
            return paymentViewModel;
        }

        public async Task<PaymentViewModel> UpdatePayment(Guid id, UpdatePaymentRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var paymentInRequest = mapper.Map<Payment>(request);
            var payment = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (payment == null)
            {
                return null;
            }
            payment.Method = paymentInRequest.Method;
            await UpdateAsyn(payment);
            return mapper.Map<PaymentViewModel>(payment);
        }

        public async Task<int> DeletePayment(Guid id)
        {
            var payment = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (payment == null)
            {
                return 0;
            }

            //product.Status = (int)Status.Inactive;
            await UpdateAsyn(payment);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
