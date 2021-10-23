using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests;
using VuonDau.Business.Requests.Customer;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class CustomerModule
    {
        public static void ConfigCustomerModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Customer, CustomerViewModel>().ReverseMap();
            mc.CreateMap<CreateCustomerRequest, Customer>();
            mc.CreateMap<UpdateCustomerRequest, Customer>();
            mc.CreateMap<UserLoginRequest, Customer>();
        }
    }
}
