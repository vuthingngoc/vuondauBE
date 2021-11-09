using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Product
{
    public class SearchProductRequest
    {
        public Guid? ProductTypeId { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
    }
}
