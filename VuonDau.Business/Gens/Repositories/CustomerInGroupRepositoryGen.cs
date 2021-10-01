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
    public partial interface ICustomerInGroupRepository :IBaseRepository<CustomerInGroup>
    {
    }
    public partial class CustomerInGroupRepository :BaseRepository<CustomerInGroup>, ICustomerInGroupRepository
    {
         public CustomerInGroupRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

