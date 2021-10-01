using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Transactions = new HashSet<Transaction>();
        }

        public string Id { get; set; }
        public string Method { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
