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
    public partial interface IHarvestService:IBaseService<Harvest>
    {
    }
    public partial class HarvestService:BaseService<Harvest>,IHarvestService
    {
        public HarvestService(IUnitOfWork unitOfWork,IHarvestRepository repository):base(unitOfWork,repository){}
    }
}
