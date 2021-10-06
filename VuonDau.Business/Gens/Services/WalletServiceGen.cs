/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////
namespace VuonDau.Business.Gens.Services
{
    using Reso.Core.BaseConnect;
    using VuonDau.Data.Repositories;
    using VuonDau.Data.Models;
    public partial interface IWalletService:IBaseService<Wallet>
    {
    }
    public partial class WalletService:BaseService<Wallet>,IWalletService
    {
        public WalletService(IUnitOfWork unitOfWork,IWalletRepository repository):base(unitOfWork,repository){}
    }
}
