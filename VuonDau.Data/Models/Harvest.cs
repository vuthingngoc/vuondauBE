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

        public string Id { get; set; }
        public string Name { get; set; }
        public string FarmId { get; set; }
        public string ProductId { get; set; }
        public string Description { get; set; }

        public virtual Farm Farm { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<HarvestSelling> HarvestSellings { get; set; }
    }
}
