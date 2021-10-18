using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.ProductInCart
{
    public class CreateProductInCartRequest
    {
        public Guid? CustomerId { get; set; }
        public Guid? ProductId { get; set; }

    }
}
