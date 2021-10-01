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
    public partial interface IHarvestSellingRepository :IBaseRepository<HarvestSelling>
    {
    }
    public partial class HarvestSellingRepository :BaseRepository<HarvestSelling>, IHarvestSellingRepository
    {
         public HarvestSellingRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

