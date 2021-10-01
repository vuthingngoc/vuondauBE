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
    public partial interface IProductTypeRepository :IBaseRepository<ProductType>
    {
    }
    public partial class ProductTypeRepository :BaseRepository<ProductType>, IProductTypeRepository
    {
         public ProductTypeRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

