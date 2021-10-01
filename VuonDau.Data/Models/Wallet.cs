using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Wallet
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public double? Balance { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
