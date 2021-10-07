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
    public partial interface IFarmTypeService:IBaseService<FarmType>
    {
    }
    public partial class FarmTypeService:BaseService<FarmType>,IFarmTypeService
    {
        public FarmTypeService(IUnitOfWork unitOfWork,IFarmTypeRepository repository):base(unitOfWork,repository){}
    }
}
