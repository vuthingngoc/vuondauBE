using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests;
using VuonDau.Business.Requests.Campaign;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class CampaignModule
    {
        public static void ConfigCampaignModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Campaign, CampaignViewModel>().ReverseMap();
            mc.CreateMap<CreateCampaignRequest, Campaign>();
            mc.CreateMap<UpdateCampaignRequest, Campaign>();
        }
    }
}
