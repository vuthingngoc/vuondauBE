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
    public partial interface IHarvestPictureRepository :IBaseRepository<HarvestPicture>
    {
    }
    public partial class HarvestPictureRepository :BaseRepository<HarvestPicture>, IHarvestPictureRepository
    {
         public HarvestPictureRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

