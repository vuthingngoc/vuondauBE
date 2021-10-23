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
    public partial interface ICampaignRepository :IBaseRepository<Campaign>
    {
    }
    public partial class CampaignRepository :BaseRepository<Campaign>, ICampaignRepository
    {
         public CampaignRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

