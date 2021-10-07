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
    public partial interface ICustomerService:IBaseService<Customer>
    {
    }
    public partial class CustomerService:BaseService<Customer>,ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork,ICustomerRepository repository):base(unitOfWork,repository){}
    }
}
