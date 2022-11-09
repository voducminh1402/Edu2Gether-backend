using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Payment;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

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
            var paymentVerify = VerifyPaymentPaypal(payment.PaypalId);
            if (paymentVerify != null)
            {
                Payment paymentTmp = _mapper.Map<Payment>(paymentVerify);
                paymentTmp.BookingId = payment.BookingId;

                Booking booking = _bookingRepository.Get().Where(x => x.Id == payment.Id).FirstOrDefault();

                paymentTmp.Booking = booking;
                var paymentAdded = _paymentRepository.Create(paymentTmp);
                _paymentRepository.Save();

                return _mapper.Map<PaymentResponseModel>(paymentAdded);
            }
            else
            {
                Booking booking = _bookingRepository.Get().Where(x => x.Id == payment.Id).FirstOrDefault();
                if (booking != null)
                {
                    _bookingRepository.Delete(booking);
                    _bookingRepository.Save();
                }
            }
            return null;
        }

        public Payment VerifyPaymentPaypal(string id)
        {
            string URL = $"https://www.sandbox.paypal.com/v2/checkout/orders/{id}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Basic QVpyWmw1UEJJc1R3Qk56ZFdSaTM0UkpGYVFFWElsZmphN2p1ZzF1M3dmZUt1WDVJR2dZeDVwc3VNaUU5eXdCWnNMai0wTWt4T2dLeU5WYjk6RU1WTENfZ2NuQlgza0QwcFFiZkFQYV9MbGFqLW9uc0RwVU5rZk9wVDUtUHE4bVdoeC1RM1BadTZ0M2l1WVRpSGktRndmNlVWN0FCcVgtQXo=");

            // List data response.
            HttpResponseMessage response = client.GetAsync(URL).Result; 
            if (response.IsSuccessStatusCode)
            {
                var payment = new Payment();
                var dataObjects = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                var returnData = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(dataObjects);
                payment.TotalPrice = (decimal)returnData["purchase_units"][0]["payments"]["captures"][0]["amount"]["value"];
                payment.PaymentType = "Paypal";
                
                if ((returnData["status"]).ToString().Equals("COMPLETED"))
                {
                    payment.Status = "Completed";
                    payment.FailReason = $"No - {returnData["id"]}";
                }
                else
                {
                    payment.Status = "Pending";
                }

                return payment;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return null;
        }

        public PaymentResponseModel FindPaymentById(int id)
        {
            var payments = _paymentRepository.Get().Where(x => x.Id == id).FirstOrDefault();

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
