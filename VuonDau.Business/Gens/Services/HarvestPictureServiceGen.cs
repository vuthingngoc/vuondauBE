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
    public partial interface IHarvestPictureService:IBaseService<HarvestPicture>
    {
    }
    public partial class HarvestPictureService:BaseService<HarvestPicture>,IHarvestPictureService
    {
        public HarvestPictureService(IUnitOfWork unitOfWork,IHarvestPictureRepository repository):base(unitOfWork,repository){}
    }
}
