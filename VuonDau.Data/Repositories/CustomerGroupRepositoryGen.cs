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
    public partial interface ICustomerGroupRepository :IBaseRepository<CustomerGroup>
    {
    }
    public partial class CustomerGroupRepository :BaseRepository<CustomerGroup>, ICustomerGroupRepository
    {
         public CustomerGroupRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

