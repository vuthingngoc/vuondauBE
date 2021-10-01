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
    public partial interface IFarmPictureRepository :IBaseRepository<FarmPicture>
    {
    }
    public partial class FarmPictureRepository :BaseRepository<FarmPicture>, IFarmPictureRepository
    {
         public FarmPictureRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

