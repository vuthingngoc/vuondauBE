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
    public partial interface IProductPictureRepository :IBaseRepository<ProductPicture>
    {
    }
    public partial class ProductPictureRepository :BaseRepository<ProductPicture>, IProductPictureRepository
    {
         public ProductPictureRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

