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
    public partial interface IFarmerRepository :IBaseRepository<Farmer>
    {
    }
    public partial class FarmerRepository :BaseRepository<Farmer>, IFarmerRepository
    {
         public FarmerRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

