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
    public partial interface IHarvestRepository :IBaseRepository<Harvest>
    {
    }
    public partial class HarvestRepository :BaseRepository<Harvest>, IHarvestRepository
    {
         public HarvestRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

