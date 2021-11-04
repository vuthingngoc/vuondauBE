using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class HarvestSelling
    {
        public HarvestSelling()
        {
            CustomerGroups = new HashSet<CustomerGroup>();
            HarvestSellingPrices = new HashSet<HarvestSellingPrice>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductInCarts = new HashSet<ProductInCart>();
        }

        public Guid Id { get; set; }
        public Guid? HarvestId { get; set; }
        public Guid? CampaignId { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? MinWeight { get; set; }
        public double? TotalWeight { get; set; }
        public int? Status { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Harvest Harvest { get; set; }
        public virtual ICollection<CustomerGroup> CustomerGroups { get; set; }
        public virtual ICollection<HarvestSellingPrice> HarvestSellingPrices { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductInCart> ProductInCarts { get; set; }
    }
}
