using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class HarvestPicture
    {
        public Guid Id { get; set; }
        public Guid? HarvestId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

        public virtual Harvest Harvest { get; set; }
    }
}
