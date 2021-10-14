using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.CustomerInGroup;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class CustomerInGroupModule
    {
        public static void ConfigCustomerInGroupModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<CustomerInGroup, CustomerInGroupViewModel>().ReverseMap();
            mc.CreateMap<CreateCustomerInGroupRequest, CustomerInGroup>();
            mc.CreateMap<UpdateCustomerInGroupRequest, CustomerInGroup>();
        }
    }
}
