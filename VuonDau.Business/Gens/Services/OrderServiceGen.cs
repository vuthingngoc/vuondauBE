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
    public partial interface IOrderService:IBaseService<Order>
    {
    }
    public partial class OrderService:BaseService<Order>,IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork,IOrderRepository repository):base(unitOfWork,repository){}
    }
}
