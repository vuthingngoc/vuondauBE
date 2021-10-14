using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class ProductInCart
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
