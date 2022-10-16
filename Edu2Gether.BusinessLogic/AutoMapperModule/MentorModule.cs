using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Mentor;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class MentorModule
    {
        public static void ConfigMentorModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Mentor, MentorResponseModel>().ReverseMap();
            mc.CreateMap<Mentor, CreateMentorRequestModel>().ReverseMap();
            mc.CreateMap<Mentor, UpdateMentorRequestModel>().ReverseMap();
        }
    }

}
