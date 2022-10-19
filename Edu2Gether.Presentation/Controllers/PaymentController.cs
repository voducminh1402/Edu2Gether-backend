using Edu2Gether.BusinessLogic.RequestModels.Payment;
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
    [Route("api/v1/payments")]
    public class PaymentController : ControllerBase
    {
        private IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<PaymentResponseModel> CreatePayment(CreatePaymentRequestModel payment)
        {
            var paymentAdded = _paymentService.CreatePayment(payment);

            if (paymentAdded == null)
            {
                return NotFound("Can't create payment!");
            }
            return Ok(paymentAdded);
        }

        [MapToApiVersion("1")]
        [HttpPatch("change-status")]
        public ActionResult<PaymentResponseModel> ChangeStatusPayment(UpdatePaymentRequestModel payment)
        {
            var paymentUpdated = _paymentService.ChangeStatusPayment(payment);

            if (paymentUpdated == null)
            {
                return NotFound("Can't change status of this payment!");
            }
            return Ok(paymentUpdated);
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<PaymentResponseModel>> GetPayments()
        {
            var payments = _paymentService.GetPayments();

            if (payments == null)
            {
                return NotFound("Can't get payment!");
            }
            return Ok(payments);
        }

        [MapToApiVersion("1")]
        [HttpGet("users/{userId}")]
        public ActionResult<List<PaymentResponseModel>> GetPaymentsByUser(string userId)
        {
            var payments = _paymentService.GetPaymentByUser(userId);

            if (payments == null)
            {
                return NotFound("Can't get payment!");
            }
            return Ok(payments);
        }

        [MapToApiVersion("1")]
        [HttpGet("date")]
        public ActionResult<List<PaymentResponseModel>> GetPaymentsByUser([FromQuery] DateTime dateStart, [FromQuery] DateTime dateEnd)
        {
            var payments = _paymentService.GetPaymentBetweenDate(dateStart, dateEnd);

            if (payments == null)
            {
                return NotFound("Can't get payments!");
            }
            return Ok(payments);
        }
    }
}
