/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////
namespace VuonDau.Business.Services
{
    using Reso.Core.BaseConnect;
    using VuonDau.Business.Repositories;
    using VuonDau.Data.Models;
    public partial interface ICustomerGroupService:IBaseService<CustomerGroup>
    {
    }
    public partial class CustomerGroupService:BaseService<CustomerGroup>,ICustomerGroupService
    {
        public CustomerGroupService(IUnitOfWork unitOfWork,ICustomerGroupRepository repository):base(unitOfWork,repository){}
    }
}
