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
    public partial interface IHarvestSellingPriceRepository :IBaseRepository<HarvestSellingPrice>
    {
    }
    public partial class HarvestSellingPriceRepository :BaseRepository<HarvestSellingPrice>, IHarvestSellingPriceRepository
    {
         public HarvestSellingPriceRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

