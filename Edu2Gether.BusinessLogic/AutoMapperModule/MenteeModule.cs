using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Mentee;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class MenteeModule
    {
        public static void ConfigMenteeModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Mentee, MenteeResponseModel>().ReverseMap();
            mc.CreateMap<Mentee, CreateMenteeRequestModel>().ReverseMap();
            mc.CreateMap<Mentee, UpdateMenteeRequestModel>().ReverseMap();
        }
    }

}
