using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class ProductInCartViewModel
    {
        [BindNever]
        public Guid? Id { get; set; }
        public virtual CustomerViewModel? Customer { get; set; }
        public virtual HarvestSellingViewModel? HarvestSelling { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
    }
}
