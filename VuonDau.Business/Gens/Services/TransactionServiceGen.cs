/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////
namespace VuonDau.Business.Services
{
    using Reso.Core.BaseConnect;
    using VuonDau.Data.Repositories;
    using VuonDau.Data.Models;
    public partial interface ITransactionService:IBaseService<Transaction>
    {
    }
    public partial class TransactionService:BaseService<Transaction>,ITransactionService
    {
        public TransactionService(IUnitOfWork unitOfWork,ITransactionRepository repository):base(unitOfWork,repository){}
    }
}
