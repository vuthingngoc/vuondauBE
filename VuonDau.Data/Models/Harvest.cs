using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Harvest
    {
        public Harvest()
        {
            HarvestSellings = new HashSet<HarvestSelling>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? FarmId { get; set; }
        public Guid? ProductId { get; set; }
        public string Description { get; set; }

        public virtual Farm Farm { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<HarvestSelling> HarvestSellings { get; set; }
    }
}
