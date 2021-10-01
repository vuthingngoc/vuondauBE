using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Farm
    {
        public Farm()
        {
            FarmPictures = new HashSet<FarmPicture>();
            Harvests = new HashSet<Harvest>();
        }

        public string Id { get; set; }
        public string FarmTypeId { get; set; }
        public string FarmerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public bool? Status { get; set; }

        public virtual FarmType FarmType { get; set; }
        public virtual Farmer Farmer { get; set; }
        public virtual ICollection<FarmPicture> FarmPictures { get; set; }
        public virtual ICollection<Harvest> Harvests { get; set; }
    }
}
