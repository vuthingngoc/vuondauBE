using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.ProductInCart
{
    public class UpdateProductInCartRequest
    {
        public Guid? CustomerId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Status { get; set; }
    }
}
