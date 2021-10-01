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
    public partial interface IHarvestSellingService:IBaseService<HarvestSelling>
    {
    }
    public partial class HarvestSellingService:BaseService<HarvestSelling>,IHarvestSellingService
    {
        public HarvestSellingService(IUnitOfWork unitOfWork,IHarvestSellingRepository repository):base(unitOfWork,repository){}
    }
}
