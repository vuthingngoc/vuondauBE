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
    public partial interface IFarmPictureService:IBaseService<FarmPicture>
    {
    }
    public partial class FarmPictureService:BaseService<FarmPicture>,IFarmPictureService
    {
        public FarmPictureService(IUnitOfWork unitOfWork,IFarmPictureRepository repository):base(unitOfWork,repository){}
    }
}
