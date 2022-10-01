using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Role;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class RoleModule
    {
        public static void ConfigRoleModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Role, RoleViewModel>().ReverseMap();
            mc.CreateMap<Role, CreateRoleRequestModel>().ReverseMap();
            mc.CreateMap<Role, UpdateRoleRequestModel>().ReverseMap();
        }
    }

}
