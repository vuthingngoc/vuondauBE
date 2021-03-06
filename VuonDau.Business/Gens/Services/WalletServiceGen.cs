/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////
namespace VuonDau.Business.Services
{
    using Reso.Core.BaseConnect;
    using VuonDau.Business.Repositories;
    using VuonDau.Data.Models;
    public partial interface IWalletService:IBaseService<Wallet>
    {
    }
    public partial class WalletService:BaseService<Wallet>,IWalletService
    {
        public WalletService(IUnitOfWork unitOfWork,IWalletRepository repository):base(unitOfWork,repository){}
    }
}
