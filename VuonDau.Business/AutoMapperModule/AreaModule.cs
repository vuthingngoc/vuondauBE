using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests;
using VuonDau.Business.Requests.Area;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class AreaModule
    {
        public static void ConfigAreaModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Area, AreaViewModel>().ReverseMap();
            mc.CreateMap<CreateAreaRequest, Area>();
            mc.CreateMap<UpdateAreaRequest, Area>();
        }
    }
}
