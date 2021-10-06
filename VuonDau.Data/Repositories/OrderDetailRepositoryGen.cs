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
    public partial interface IOrderDetailRepository :IBaseRepository<OrderDetail>
    {
    }
    public partial class OrderDetailRepository :BaseRepository<OrderDetail>, IOrderDetailRepository
    {
         public OrderDetailRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

