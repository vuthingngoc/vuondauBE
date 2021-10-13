using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class FarmPicture
    {
        public Guid Id { get; set; }
        public Guid? FarmId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
