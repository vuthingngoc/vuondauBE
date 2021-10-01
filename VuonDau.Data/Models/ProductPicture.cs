using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class ProductPicture
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

        public virtual Product Product { get; set; }
    }
}
