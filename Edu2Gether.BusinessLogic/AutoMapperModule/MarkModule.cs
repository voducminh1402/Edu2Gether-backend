using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Mark;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class MarkModule
    {
        public static void ConfigMarkModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Mark, MarkViewModel>().ReverseMap();
            mc.CreateMap<Mark, CreateMarkRequestModel>().ReverseMap();
            mc.CreateMap<Mark, UpdateMarkRequestModel>().ReverseMap();
        }
    }

}
