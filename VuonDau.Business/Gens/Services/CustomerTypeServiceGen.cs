/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////
namespace VuonDau.Business.Gens.Services
{
    using Reso.Core.BaseConnect;
    using VuonDau.Data.Repositories;
    using VuonDau.Data.Models;
    public partial interface ICustomerTypeService:IBaseService<CustomerType>
    {
    }
    public partial class CustomerTypeService:BaseService<CustomerType>,ICustomerTypeService
    {
        public CustomerTypeService(IUnitOfWork unitOfWork,ICustomerTypeRepository repository):base(unitOfWork,repository){}
    }
}
