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
    public partial interface IPaymentRepository :IBaseRepository<Payment>
    {
    }
    public partial class PaymentRepository :BaseRepository<Payment>, IPaymentRepository
    {
         public PaymentRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

