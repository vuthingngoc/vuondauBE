using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class ProductInCart
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? HarvestSellingId { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual HarvestSelling HarvestSelling { get; set; }
    }
}
