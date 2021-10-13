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
            ProductInCarts = new HashSet<ProductInCart>();
            ProductPictures = new HashSet<ProductPicture>();
        }

        public Guid Id { get; set; }
        public Guid? ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DataOfCreate { get; set; }
        public int? Status { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<Harvest> Harvests { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductInCart> ProductInCarts { get; set; }
        public virtual ICollection<ProductPicture> ProductPictures { get; set; }
    }
}
