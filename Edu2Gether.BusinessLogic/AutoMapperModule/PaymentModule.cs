using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Payment;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class PaymentModule
    {
        public static void ConfigPaymentModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Payment, PaymentViewModel>().ReverseMap();
            mc.CreateMap<Payment, CreatePaymentRequestModel>().ReverseMap();
            mc.CreateMap<Payment, UpdatePaymentRequestModel>().ReverseMap();
        }
    }

}
