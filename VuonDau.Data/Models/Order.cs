using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Order
    {
        public Order()
        {
            Feedbacks = new HashSet<Feedback>();
            OrderDetails = new HashSet<OrderDetail>();
            Transactions = new HashSet<Transaction>();
        }

        public string Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public string Address { get; set; }
        public double? TotalPrice { get; set; }
        public bool? Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
