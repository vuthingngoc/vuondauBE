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
    public partial interface IPaymentService:IBaseService<Payment>
    {
    }
    public partial class PaymentService:BaseService<Payment>,IPaymentService
    {
        public PaymentService(IUnitOfWork unitOfWork,IPaymentRepository repository):base(unitOfWork,repository){}
    }
}
