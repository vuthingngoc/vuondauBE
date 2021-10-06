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
    public partial interface IOrderRepository :IBaseRepository<Order>
    {
    }
    public partial class OrderRepository :BaseRepository<Order>, IOrderRepository
    {
         public OrderRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

