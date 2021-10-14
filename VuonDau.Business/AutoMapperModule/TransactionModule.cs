using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.Transaction;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class TransactionModule
    {
        public static void ConfigTransactionModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Transaction, TransactionViewModel>().ReverseMap();
            mc.CreateMap<CreateTransactionRequest, Transaction>();
            mc.CreateMap<UpdateTransactionRequest, Transaction>();
        }
    }
}
