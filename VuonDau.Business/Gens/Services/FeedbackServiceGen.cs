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
    public partial interface IFeedbackService:IBaseService<Feedback>
    {
    }
    public partial class FeedbackService:BaseService<Feedback>,IFeedbackService
    {
        public FeedbackService(IUnitOfWork unitOfWork,IFeedbackRepository repository):base(unitOfWork,repository){}
    }
}
