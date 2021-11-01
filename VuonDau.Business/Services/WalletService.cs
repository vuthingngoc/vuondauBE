using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Wallet;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Reso.Core.Utilities;

namespace VuonDau.Business.Services
{
    public partial interface IWalletService
    {
        Task<List<WalletViewModel>> GetAllWallets(WalletViewModel filter);
        Task<WalletViewModel> GetWalletById(Guid id);
        Task<List<WalletViewModel>> GetWalletByCustomerId(Guid id);
        Task<WalletViewModel> CreateWallet(CreateWalletRequest request);
        Task<WalletViewModel> UpdateWallet(Guid id, UpdateWalletRequest request);
        Task<int> DeleteWallet(Guid id);
    }


    public partial class WalletService
    {
        private readonly IConfigurationProvider _mapper;

        public WalletService(IUnitOfWork unitOfWork, IWalletRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<WalletViewModel>> GetAllWallets(WalletViewModel filter)
        {
            return await Get().ProjectTo<WalletViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
        }

        public async Task<WalletViewModel> GetWalletById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<WalletViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<List<WalletViewModel>> GetWalletByCustomerId(Guid CustomerId)
        {
            return await Get(p => p.CustomerId == CustomerId).ProjectTo<WalletViewModel>(_mapper).ToListAsync();
        }
        public async Task<WalletViewModel> CreateWallet(CreateWalletRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var wallet = mapper.Map<Wallet>(request);
            await CreateAsyn(wallet);
            var walletViewModel = mapper.Map<WalletViewModel>(wallet);
            return walletViewModel;
        }

        public async Task<WalletViewModel> UpdateWallet(Guid id, UpdateWalletRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var walletInRequest = mapper.Map<Wallet>(request);
            var wallet = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (wallet == null)
            {
                return null;
            }
            wallet.CustomerId = walletInRequest.CustomerId;
            wallet.Balance = walletInRequest.Balance;
            await UpdateAsyn(wallet);
            return mapper.Map<WalletViewModel>(wallet);
        }

        public async Task<int> DeleteWallet(Guid id)
        {
            var wallet = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (wallet == null)
            {
                return 0;
            }

            //product.Status = (int)Status.Inactive;
            await UpdateAsyn(wallet);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
