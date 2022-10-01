using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Major;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class MajorModule
    {
        public static void ConfigMajorModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Major, MajorViewModel>().ReverseMap();
            mc.CreateMap<Major, CreateMajorRequestModel>().ReverseMap();
            mc.CreateMap<Major, UpdateMajorRequestModel>().ReverseMap();
        }
    }

}
