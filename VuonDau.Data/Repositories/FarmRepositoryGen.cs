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
    public partial interface IFarmRepository :IBaseRepository<Farm>
    {
    }
    public partial class FarmRepository :BaseRepository<Farm>, IFarmRepository
    {
         public FarmRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

