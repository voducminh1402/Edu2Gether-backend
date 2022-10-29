using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Slot;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class SlotModule
    {
        public static void ConfigSlotModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Slot, SlotResponseModel>().ReverseMap();
            mc.CreateMap<Slot, CreateSlotRequestModel>().ReverseMap();
            mc.CreateMap<Slot, UpdateSlotRequestModel>().ReverseMap();
        }
    }

}
