using AutoMapper;
using Edu2Gether.BusinessLogic.Commons;
using Edu2Gether.BusinessLogic.RequestModels.Booking;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface IBookingService {
        BookingResponseModel CreateBooking(CreateBookingRequestModel booking);
        BookingResponseModel CancelBooking(int bookingId);
        List<BookingResponseModel> ViewBookingByMentee(string menteeId);
        List<BookingResponseModel> ViewBookingByMentor(string mentorId);
        List<BookingResponseModel> ViewAllBooking();
        BookingResponseModel ViewBookingById(int bookingId);

    }

    public class BookingService : IBookingService {

        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public BookingResponseModel CancelBooking(int bookingId)
        {
            Booking booking = _bookingRepository.Get().Where(X => X.Id == bookingId).FirstOrDefault();

            booking.Status = BookingConst.CANCELLED;
            var returnBooking = _bookingRepository.Update(booking);
            _bookingRepository.Save();

            if (returnBooking == null)
            {
                return null;
            }

            return _mapper.Map<BookingResponseModel>(booking);
        }

        public BookingResponseModel CreateBooking(CreateBookingRequestModel booking)
        {
            var bookingCreated = _bookingRepository.Create(_mapper.Map<Booking>(booking));
            _bookingRepository.Save();

            if (bookingCreated == null)
            {
                return null;
            }

            return _mapper.Map<BookingResponseModel>(bookingCreated);
        }

        public List<BookingResponseModel> ViewAllBooking()
        {
            var bookings = _bookingRepository.Get()
                                            .Include(x => x.Mentee)
                                            .Include(x => x.Course)
                                            .ThenInclude(x => x.Mentor).ToList();

            return _mapper.Map<List<BookingResponseModel>>(bookings);
        }

        public BookingResponseModel ViewBookingById(int bookingId)
        {
            var booking = _bookingRepository.Get()
                                            .Include(x => x.Mentee)
                                            .Include(x => x.Course)
                                            .ThenInclude(x => x.Mentor).Where(X => X.Id == bookingId).FirstOrDefault();

            return _mapper.Map<BookingResponseModel>(booking);
        }

        public List<BookingResponseModel> ViewBookingByMentee(string menteeId)
        {
            var booking = _bookingRepository.Get()
                                            .Include(x => x.Mentee)
                                            .Include(x => x.Course)
                                            .ThenInclude(x => x.Mentor).Where(X => X.MenteeId.Equals(menteeId));


            return _mapper.Map<List<BookingResponseModel>>(booking);
        }

        public List<BookingResponseModel> ViewBookingByMentor(string mentorId)
        {
            var booking = _bookingRepository.Get()
                                            .Include(x => x.Mentee)
                                            .Include(x => x.Course)
                                            .ThenInclude(x => x.Mentor).Where(X => X.MentorId.Equals(mentorId));


            return _mapper.Map<List<BookingResponseModel>>(booking);
        }
    }

}
