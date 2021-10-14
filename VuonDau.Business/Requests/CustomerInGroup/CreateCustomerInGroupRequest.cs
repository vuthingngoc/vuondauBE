using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.CustomerInGroup
{
    public class CreateCustomerInGroupRequest
    {
        public Guid CustomerId { get; set; }
        public Guid CustomerGroupId { get; set; }
        public DateTime? JoinDate { get; set; }

    }
}
