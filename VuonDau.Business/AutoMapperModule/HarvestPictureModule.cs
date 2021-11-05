using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.HarvestPicture;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class HarvestPictureModule
    {
        public static void ConfigHarvestPictureModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<HarvestPicture, HarvestPictureViewModel>().ReverseMap();
            mc.CreateMap<CreateHarvestPictureRequest, HarvestPicture>();
            mc.CreateMap<UpdateHarvestPictureRequest, HarvestPicture>();
        }
    }
}
