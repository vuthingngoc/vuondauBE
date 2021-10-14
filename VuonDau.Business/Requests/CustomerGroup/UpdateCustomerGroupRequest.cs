using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.CustomerGroup
{
    public class UpdateCustomerGroupRequest
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public Guid? HarvestSellingId { get; set; }
    }
}
