﻿using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class FarmPicture
    {
        public int Id { get; set; }
        public int? FarmId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
