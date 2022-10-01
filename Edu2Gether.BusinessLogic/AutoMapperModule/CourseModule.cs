using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Course;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class CourseModule
    {
        public static void ConfigCourseModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Course, CourseViewModel>().ReverseMap();
            mc.CreateMap<Course, CreateCourseRequestModel>().ReverseMap();
            mc.CreateMap<Course, UpdateCourseRequestModel>().ReverseMap();
        }
    }

}
