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
    public partial interface IProductRepository :IBaseRepository<Product>
    {
    }
    public partial class ProductRepository :BaseRepository<Product>, IProductRepository
    {
         public ProductRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

