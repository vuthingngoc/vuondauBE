using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.CustomerType;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class CustomerTypeModule
    {
        public static void ConfigCustomerTypeModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<CustomerType, CustomerTypeViewModel>().ReverseMap();
            mc.CreateMap<CreateCustomerTypeRequest, CustomerType>();
            mc.CreateMap<UpdateCustomerTypeRequest, CustomerType>();
        }
    }
}
