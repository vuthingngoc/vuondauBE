using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class CustomerGroup
    {
        public CustomerGroup()
        {
            CustomerInGroups = new HashSet<CustomerInGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int? HarvestSellingId { get; set; }

        public virtual HarvestSelling HarvestSelling { get; set; }
        public virtual ICollection<CustomerInGroup> CustomerInGroups { get; set; }
    }
}
