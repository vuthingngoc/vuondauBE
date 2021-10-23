using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.Farm;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class FarmModule
    {
        public static void ConfigFarmModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Farm, FarmViewModel>().ReverseMap();
            mc.CreateMap<CreateFarmRequest, Farm>();
            mc.CreateMap<UpdateFarmRequest, Farm>();
        }
    }
}
