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
    public partial interface IFeedbackRepository :IBaseRepository<Feedback>
    {
    }
    public partial class FeedbackRepository :BaseRepository<Feedback>, IFeedbackRepository
    {
         public FeedbackRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

