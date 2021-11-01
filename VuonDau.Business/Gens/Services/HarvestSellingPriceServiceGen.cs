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
    public partial interface IHarvestSellingPriceService:IBaseService<HarvestSellingPrice>
    {
    }
    public partial class HarvestSellingPriceService : BaseService<HarvestSellingPrice>, IHarvestSellingPriceService
    {
        public HarvestSellingPriceService(IUnitOfWork unitOfWork,IHarvestSellingPriceRepository repository):base(unitOfWork,repository){}
    }
}
