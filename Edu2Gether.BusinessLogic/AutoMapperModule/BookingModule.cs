using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Booking;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;


namespace Edu2Gether.BusinessLogic.AutoMapperModule 
{

   public static class BookingModule
    {
        public static void ConfigBookingModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Booking, BookingResponseModel>().ReverseMap();
            mc.CreateMap<Booking, CreateBookingRequestModel>().ReverseMap();
            mc.CreateMap<Booking, UpdateBookingRequestModel>().ReverseMap();
        }
    }

}
