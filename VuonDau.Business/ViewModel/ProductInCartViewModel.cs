using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class ProductInCartViewModel
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? HarvestSellingId { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
    }
}
