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

