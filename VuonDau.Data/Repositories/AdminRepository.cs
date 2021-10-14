using Microsoft.EntityFrameworkCore;
using Reso.Core.BaseConnect;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Data.Repositories
{
    public partial interface IAdminRepository : IBaseRepository<Admin>
    {
    }
    public partial class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
