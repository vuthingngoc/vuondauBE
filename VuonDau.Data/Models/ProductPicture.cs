using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class ProductPicture
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

        public virtual Product Product { get; set; }
    }
}
