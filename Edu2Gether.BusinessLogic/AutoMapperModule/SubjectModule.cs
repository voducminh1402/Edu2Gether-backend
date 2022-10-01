using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Subject;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class SubjectModule
    {
        public static void ConfigSubjectModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Subject, SubjectViewModel>().ReverseMap();
            mc.CreateMap<Subject, CreateSubjectRequestModel>().ReverseMap();
            mc.CreateMap<Subject, UpdateSubjectRequestModel>().ReverseMap();
        }
    }

}
