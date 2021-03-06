using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerInGroups = new HashSet<CustomerInGroup>();
            Orders = new HashSet<Order>();
            Wallets = new HashSet<Wallet>();
        }

        public string Id { get; set; }
        public string CustomerType { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public bool? Status { get; set; }

        public virtual CustomerType CustomerTypeNavigation { get; set; }
        public virtual ICollection<CustomerInGroup> CustomerInGroups { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
