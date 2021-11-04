using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Farm
{
    public class CreateFarmRequest
    {
        public Guid? FarmTypeId { get; set; }
        public Guid? FarmerId { get; set; }
        public Guid? AreaId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

    }
}
