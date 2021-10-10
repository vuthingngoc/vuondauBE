using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DataOfCreate { get; set; }
        public int? Status { get; set; }
    }
}
