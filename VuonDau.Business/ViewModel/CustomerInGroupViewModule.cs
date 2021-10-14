using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class CustomerInGroupViewModel
    {
        public Guid CustomerId { get; set; }
        public Guid CustomerGroupId { get; set; }
        public DateTime? JoinDate { get; set; }
    }
}
