/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using Reso.Core.BaseConnect;
using VuonDau.Data.Models;
namespace VuonDau.Data.Repositories
{
    public partial interface IWalletRepository :IBaseRepository<Wallet>
    {
    }
    public partial class WalletRepository :BaseRepository<Wallet>, IWalletRepository
    {
         public WalletRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

