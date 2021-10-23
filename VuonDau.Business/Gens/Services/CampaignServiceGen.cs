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
    public partial interface ICampaignService:IBaseService<Campaign>
    {
    }
    public partial class CampaignService:BaseService<Campaign>,ICampaignService
    {
        public CampaignService(IUnitOfWork unitOfWork,ICampaignRepository repository):base(unitOfWork,repository){}
    }
}
