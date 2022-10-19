using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Payment;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface IPaymentService {
        PaymentResponseModel CreatePayment(CreatePaymentRequestModel payment);
        PaymentResponseModel ChangeStatusPayment(UpdatePaymentRequestModel payment);
        PaymentResponseModel FindPaymentById(int id);
        List<PaymentResponseModel> GetPayments();
        List<PaymentResponseModel> GetPaymentByUser(string userId);
        List<PaymentResponseModel> GetPaymentBetweenDate(DateTime dateStart, DateTime dateEnd);

    }

    public class PaymentService : IPaymentService {

        private readonly IPaymentRepository _paymentRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper, IBookingRepository bookingRepository)
        {
            _paymentRepository = paymentRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public PaymentResponseModel ChangeStatusPayment(UpdatePaymentRequestModel payment)
        {
            Payment paymentExisted = _paymentRepository.Get().Where(x => x.Id == payment.Id).FirstOrDefault();
            paymentExisted.Status = payment.Status;
            var paymentUpdated = _paymentRepository.Update(paymentExisted);
            _paymentRepository.Save();

            return _mapper.Map<PaymentResponseModel>(paymentUpdated);
        }

        public PaymentResponseModel CreatePayment(CreatePaymentRequestModel payment)
        {
            Booking booking = _bookingRepository.Get().Where(x => x.Id == payment.Id).FirstOrDefault();
            Payment paymentTmp = _mapper.Map<Payment>(payment);
            paymentTmp.Booking = booking;
            var paymentAdded = _paymentRepository.Create(paymentTmp);
            _paymentRepository.Save();

            return _mapper.Map<PaymentResponseModel>(paymentAdded);
        }

        public PaymentResponseModel FindPaymentById(int id)
        {
            var payments = _paymentRepository.Get().Where(x => x.Id == id).ToList();

            return _mapper.Map<PaymentResponseModel>(payments);
        }

        public List<PaymentResponseModel> GetPaymentBetweenDate(DateTime dateStart, DateTime dateEnd)
        {
            var payments = _paymentRepository.Get().Where(x => x.Booking.BookingTime >= dateStart && x.Booking.BookingTime <= dateEnd).ToList();

            return _mapper.Map<List<PaymentResponseModel>>(payments);
        }

        public List<PaymentResponseModel> GetPaymentByUser(string userId)
        {
            var payments = _paymentRepository.Get().Where(x => x.Booking.MentorId.Equals(userId) || x.Booking.MenteeId.Equals(userId)).ToList();

            return _mapper.Map<List<PaymentResponseModel>>(payments);
        }

        public List<PaymentResponseModel> GetPayments()
        {
            var payments = _paymentRepository.Get().ToList();

            return _mapper.Map<List<PaymentResponseModel>>(payments);
        }
    }

}
