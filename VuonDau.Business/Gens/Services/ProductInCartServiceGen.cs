using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Services
{
    using Reso.Core.BaseConnect;
    using VuonDau.Data.Repositories;
    using VuonDau.Data.Models;
    public partial interface IProductInCartService : IBaseService<ProductInCart>
    {
    }
    public partial class ProductInCartService : BaseService<ProductInCart>, IProductInCartService
    {
        public ProductInCartService(IUnitOfWork unitOfWork, IProductInCartRepository repository) : base(unitOfWork, repository) { }
    }
}
