/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////
namespace VuonDau.Business.Services
{
    using Reso.Core.BaseConnect;
    using VuonDau.Data.Repositories;
    using VuonDau.Data.Models;
    public partial interface ICustomerInGroupService:IBaseService<CustomerInGroup>
    {
    }
    public partial class CustomerInGroupService:BaseService<CustomerInGroup>,ICustomerInGroupService
    {
        public CustomerInGroupService(IUnitOfWork unitOfWork,ICustomerInGroupRepository repository):base(unitOfWork,repository){}
    }
}
