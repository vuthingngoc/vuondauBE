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
    public partial interface IFarmerService:IBaseService<Farmer>
    {
    }
    public partial class FarmerService:BaseService<Farmer>,IFarmerService
    {
        public FarmerService(IUnitOfWork unitOfWork,IFarmerRepository repository):base(unitOfWork,repository){}
    }
}
