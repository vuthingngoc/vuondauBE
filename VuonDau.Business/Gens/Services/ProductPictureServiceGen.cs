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
    public partial interface IProductPictureService:IBaseService<ProductPicture>
    {
    }
    public partial class ProductPictureService:BaseService<ProductPicture>,IProductPictureService
    {
        public ProductPictureService(IUnitOfWork unitOfWork,IProductPictureRepository repository):base(unitOfWork,repository){}
    }
}
