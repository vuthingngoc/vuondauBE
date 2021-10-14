using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.FarmPicture;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class FarmPictureModule
    {
        public static void ConfigFarmPictureModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<FarmPicture, FarmPictureViewModel>().ReverseMap();
            mc.CreateMap<CreateFarmPictureRequest, FarmPicture>();
            mc.CreateMap<UpdateFarmPictureRequest, FarmPicture>();
        }
    }
}
