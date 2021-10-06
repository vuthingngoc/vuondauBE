using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            Harvests = new HashSet<Harvest>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductPictures = new HashSet<ProductPicture>();
        }

        public int Id { get; set; }
        public int? ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DataOfCreate { get; set; }
        public int? Status { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<Harvest> Harvests { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductPicture> ProductPictures { get; set; }
    }
}
