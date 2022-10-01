using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.MentorMajor;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class MentorMajorModule
    {
        public static void ConfigMentorMajorModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<MentorMajor, MentorMajorViewModel>().ReverseMap();
            mc.CreateMap<MentorMajor, CreateMentorMajorRequestModel>().ReverseMap();
            mc.CreateMap<MentorMajor, UpdateMentorMajorRequestModel>().ReverseMap();
        }
    }

}
