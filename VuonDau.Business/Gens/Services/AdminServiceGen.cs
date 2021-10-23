using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Services
{
    using Reso.Core.BaseConnect;
    using VuonDau.Data.Repositories;
    using VuonDau.Data.Models;
    public partial interface IAdminService : IBaseService<Admin>
    {
    }
    public partial class AdminService : BaseService<Admin>, IAdminService
    {
        public AdminService(IUnitOfWork unitOfWork, IAdminRepository repository) : base(unitOfWork, repository) { }
    }
}
