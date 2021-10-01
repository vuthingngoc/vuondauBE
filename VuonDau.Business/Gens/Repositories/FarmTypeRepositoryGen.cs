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
    public partial interface IFarmTypeRepository :IBaseRepository<FarmType>
    {
    }
    public partial class FarmTypeRepository :BaseRepository<FarmType>, IFarmTypeRepository
    {
         public FarmTypeRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

