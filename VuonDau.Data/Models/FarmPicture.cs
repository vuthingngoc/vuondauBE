using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class FarmPicture
    {
        public string Id { get; set; }
        public string FarmId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
