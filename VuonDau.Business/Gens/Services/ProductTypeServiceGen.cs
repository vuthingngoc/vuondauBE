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
    public partial interface IProductTypeService:IBaseService<ProductType>
    {
    }
    public partial class ProductTypeService:BaseService<ProductType>,IProductTypeService
    {
        public ProductTypeService(IUnitOfWork unitOfWork,IProductTypeRepository repository):base(unitOfWork,repository){}
    }
}
