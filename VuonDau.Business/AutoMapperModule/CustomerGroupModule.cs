using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.CustomerGroup;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class CustomerGroupModule
    {
        public static void ConfigCustomerGroupModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<CustomerGroup, CustomerGroupViewModel>().ReverseMap();
            mc.CreateMap<CreateCustomerGroupRequest, CustomerGroup>();
            mc.CreateMap<UpdateCustomerGroupRequest, CustomerGroup>();
        }
    }
}
