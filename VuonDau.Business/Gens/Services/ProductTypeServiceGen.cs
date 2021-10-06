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
    public partial interface IProductTypeService:IBaseService<ProductType>
    {
    }
    public partial class ProductTypeService:BaseService<ProductType>,IProductTypeService
    {
        public ProductTypeService(IUnitOfWork unitOfWork,IProductTypeRepository repository):base(unitOfWork,repository){}
    }
}
