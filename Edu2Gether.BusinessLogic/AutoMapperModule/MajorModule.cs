using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Major;
using Edu2Gether.BusinessLogic.ServiceModels.ResponseModels;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class MajorModule
    {
        public static void ConfigMajorModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Major, MajorResponseModel>().ReverseMap();
            mc.CreateMap<MajorResponseModel, Major>().ReverseMap();
            mc.CreateMap<Major, CreateMajorRequestModel>().ReverseMap();
            mc.CreateMap<Major, UpdateMajorRequestModel>().ReverseMap();
        }
    }

}
