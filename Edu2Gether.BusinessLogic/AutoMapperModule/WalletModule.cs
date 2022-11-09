using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Wallet;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class WalletModule
    {
        public static void ConfigWalletModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Wallet, WalletResponseModel>().ReverseMap();
            mc.CreateMap<Wallet, CreateWalletRequestModel>().ReverseMap();
            mc.CreateMap<Wallet, UpdateWalletRequestModel>().ReverseMap();
        }
    }

}
