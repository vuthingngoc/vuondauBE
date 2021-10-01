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
    public partial interface ICustomerRepository :IBaseRepository<Customer>
    {
    }
    public partial class CustomerRepository :BaseRepository<Customer>, ICustomerRepository
    {
         public CustomerRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

