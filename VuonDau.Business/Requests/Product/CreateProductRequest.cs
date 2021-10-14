using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Product
{
    public class CreateProductRequest
    {
        public Guid ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
