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
    public partial interface IAreaRepository :IBaseRepository<Area>
    {
    }
    public partial class AreaRepository :BaseRepository<Area>, IAreaRepository
    {
         public AreaRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

