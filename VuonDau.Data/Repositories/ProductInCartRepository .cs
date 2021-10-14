using Microsoft.EntityFrameworkCore;
using Reso.Core.BaseConnect;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Data.Repositories
{
    public partial interface IProductInCartRepository : IBaseRepository<ProductInCart>
    {
    }
    public partial class ProductInCartRepository : BaseRepository<ProductInCart>, IProductInCartRepository
    {
        public ProductInCartRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
