using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.CustomerGroup
{
    public class CreateCustomerGroupRequest
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public Guid? HarvestSellingId { get; set; }

    }
}
