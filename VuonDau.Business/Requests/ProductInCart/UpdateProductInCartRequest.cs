using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.ProductInCart
{
    public class UpdateProductInCartRequest
    {
        public Guid? CustomerId { get; set; }
        public Guid? HarvestSellingId { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
    }
}
