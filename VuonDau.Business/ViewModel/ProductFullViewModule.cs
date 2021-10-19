using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class ProductFullViewModel
    {
        public Guid Id { get; set; }
        public virtual ProductType ProductType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DataOfCreate { get; set; }
        public int? Status { get; set; }
    }
}
