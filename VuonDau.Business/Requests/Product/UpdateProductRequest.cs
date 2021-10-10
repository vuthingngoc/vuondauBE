using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Farmer
{
    public class UpdateProductRequest
    {
        public string ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
    }
}
