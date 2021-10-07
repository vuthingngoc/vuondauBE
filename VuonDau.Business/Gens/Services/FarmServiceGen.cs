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
    public partial interface IFarmService:IBaseService<Farm>
    {
    }
    public partial class FarmService:BaseService<Farm>,IFarmService
    {
        public FarmService(IUnitOfWork unitOfWork,IFarmRepository repository):base(unitOfWork,repository){}
    }
}
