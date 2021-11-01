﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class FarmFullViewModel
    {
        [BindNever]
        public Guid? Id { get; set; }
        public Guid? FarmTypeId { get; set; }
        public Guid? FarmerId { get; set; }
        public Guid? AreaId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? Status { get; set; }
    }
}
