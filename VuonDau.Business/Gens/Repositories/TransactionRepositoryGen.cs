/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using Reso.Core.BaseConnect;
using VuonDau.Data.Models;
namespace VuonDau.Business.Repositories
{
    public partial interface ITransactionRepository :IBaseRepository<Transaction>
    {
    }
    public partial class TransactionRepository :BaseRepository<Transaction>, ITransactionRepository
    {
         public TransactionRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

