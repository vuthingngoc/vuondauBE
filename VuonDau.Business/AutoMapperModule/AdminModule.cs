using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class AdminModule
    {
        public static void ConfigAdminModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Admin, AdminViewModel>().ReverseMap();
        }
    }
}
