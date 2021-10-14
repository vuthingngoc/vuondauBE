using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.Feedback;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class FeedbackModule
    {
        public static void ConfigFeedbackModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Feedback, FeedbackViewModel>().ReverseMap();
            mc.CreateMap<CreateFeedbackRequest, Feedback>();
            mc.CreateMap<UpdateFeedbackRequest, Feedback>();
        }
    }
}
