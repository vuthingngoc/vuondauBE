using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Transaction;
using AutoMapper.QueryableExtensions;
using AutoMapper;
namespace VuonDau.Business.Services
{
    public partial interface ITransactionService
    {
        Task<List<TransactionViewModel>> GetAllTransactions();
        Task<TransactionViewModel> GetTransactionById(Guid id);
        Task<TransactionViewModel> CreateTransaction(CreateTransactionRequest request);
        Task<TransactionViewModel> UpdateTransaction(Guid id, UpdateTransactionRequest request);
        Task<int> DeleteTransaction(Guid id);
    }


    public partial class TransactionService
    {
        private readonly IConfigurationProvider _mapper;

        public TransactionService(IUnitOfWork unitOfWork, ITransactionRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<TransactionViewModel>> GetAllTransactions()
        {
            return await Get(p => p.Status == (int)Status.Active).ProjectTo<TransactionViewModel>(_mapper).ToListAsync();
        }

        public async Task<TransactionViewModel> GetTransactionById(Guid id)
        {
            return await Get(p => p.Id == id && p.Status == (int)Status.Active).ProjectTo<TransactionViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<TransactionViewModel> CreateTransaction(CreateTransactionRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var transaction = mapper.Map<Transaction>(request);
            transaction.Status = (int)Status.Active;
            await CreateAsyn(transaction);
            var transactionViewModel = mapper.Map<TransactionViewModel>(transaction);
            return transactionViewModel;
        }

        public async Task<TransactionViewModel> UpdateTransaction(Guid id, UpdateTransactionRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var transactionInRequest = mapper.Map<Transaction>(request);
            var transaction = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (transaction == null)
            {
                return null;
            }
            transaction.OrderId = transactionInRequest.OrderId;
            transaction.Price = transactionInRequest.Price;
            transaction.PaymentId = transactionInRequest.PaymentId;
            transaction.Description = transactionInRequest.Description;
            transaction.Status = 1;
            await UpdateAsyn(transaction);
            return mapper.Map<TransactionViewModel>(transaction);
        }

        public async Task<int> DeleteTransaction(Guid id)
        {
            var transaction = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (transaction == null)
            {
                return 0;
            }

            transaction.Status = (int)Status.Inactive;
            await UpdateAsyn(transaction);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
