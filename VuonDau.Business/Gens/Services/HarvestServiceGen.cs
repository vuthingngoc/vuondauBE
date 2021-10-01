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
    public partial interface IHarvestService:IBaseService<Harvest>
    {
    }
    public partial class HarvestService:BaseService<Harvest>,IHarvestService
    {
        public HarvestService(IUnitOfWork unitOfWork,IHarvestRepository repository):base(unitOfWork,repository){}
    }
}
