using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class CustomerGroupViewModel
    {
        [BindNever]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual HarvestSellingViewModel? HarvestSelling { get; set; }
    }
}
