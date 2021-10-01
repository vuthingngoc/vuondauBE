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
    public partial interface IProductService:IBaseService<Product>
    {
    }
    public partial class ProductService:BaseService<Product>,IProductService
    {
        public ProductService(IUnitOfWork unitOfWork,IProductRepository repository):base(unitOfWork,repository){}
    }
}
