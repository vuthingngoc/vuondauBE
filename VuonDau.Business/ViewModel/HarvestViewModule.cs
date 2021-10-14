using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class HarvestViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? FarmId { get; set; }
        public Guid? ProductId { get; set; }
        public string Description { get; set; }
    }
}
