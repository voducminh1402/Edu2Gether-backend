using Edu2Gether.BusinessLogic.RequestModels.Booking;
using Edu2Gether.BusinessLogic.Services;
using Edu2Gether.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu2Gether.Presentation.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<BookingResponseModel>> GetBookings()
        {
            return _bookingService.ViewAllBooking();
        }

        [MapToApiVersion("1")]
        [HttpGet("mentees/{menteeId}")]
        public ActionResult<List<BookingResponseModel>> GetBookingByMentee(string menteeId)
        {
            return _bookingService.ViewBookingByMentee(menteeId);
        }

        [MapToApiVersion("1")]
        [HttpGet("mentors/{mentorId}")]
        public ActionResult<List<BookingResponseModel>> GetBookingByMentor(string mentorId)
        {
            return _bookingService.ViewBookingByMentor(mentorId);
        }

        [MapToApiVersion("1")]
        [HttpGet("{bookingId}")]
        public ActionResult<BookingResponseModel> FindBookingById(int bookingId)
        {
            return _bookingService.ViewBookingById(bookingId);
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<BookingResponseModel> CreateBooking(CreateBookingRequestModel booking)
        {
            var bookingCreated = _bookingService.CreateBooking(booking);

            if (bookingCreated == null)
            {
                return NotFound("Can't create booking");
            }

            return bookingCreated;
        }

        [MapToApiVersion("1")]
        [HttpPut("{bookingId}")]
        public ActionResult<BookingResponseModel> CancleBooking(int bookingId)
        {
            var bookingCancled = _bookingService.CancelBooking(bookingId);

            if (bookingCancled == null)
            {
                return NotFound("Can't cancle booking");
            }

            return bookingCancled;
        }
    }
}
