using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Transaction;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class TransactionModule
    {
        public static void ConfigTransactionModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Transaction, TransactionViewModel>().ReverseMap();
            mc.CreateMap<Transaction, CreateTransactionRequestModel>().ReverseMap();
            mc.CreateMap<Transaction, UpdateTransactionRequestModel>().ReverseMap();
        }
    }

}
