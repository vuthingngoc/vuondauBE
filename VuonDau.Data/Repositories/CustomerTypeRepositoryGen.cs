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
    public partial interface ICustomerTypeRepository :IBaseRepository<CustomerType>
    {
    }
    public partial class CustomerTypeRepository :BaseRepository<CustomerType>, ICustomerTypeRepository
    {
         public CustomerTypeRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

