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
    public partial interface IOrderDetailService:IBaseService<OrderDetail>
    {
    }
    public partial class OrderDetailService:BaseService<OrderDetail>,IOrderDetailService
    {
        public OrderDetailService(IUnitOfWork unitOfWork,IOrderDetailRepository repository):base(unitOfWork,repository){}
    }
}
