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
    public partial interface IAreaService:IBaseService<Area>
    {
    }
    public partial class AreaService:BaseService<Area>,IAreaService
    {
        public AreaService(IUnitOfWork unitOfWork,IAreaRepository repository):base(unitOfWork,repository){}
    }
}
