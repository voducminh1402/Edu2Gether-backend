using Edu2Gether.BusinessLogic.RequestModels.Transaction;
using Edu2Gether.BusinessLogic.Services;
using Edu2Gether.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu2Gether.Presentation.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/transactions")]
    public class TransactionController : ControllerBase
    {
        private ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [MapToApiVersion("1")]
        [HttpGet("users/{userId}")]
        public ActionResult<List<TransactionResponseModel>> GetTransactionByUser(string userId)
        {
            var transactions = _transactionService.GetTransactionByUser(userId);

            if (transactions == null)
            {
                return NotFound("Can't get transaction!");
            }
            return Ok(transactions);
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<TransactionResponseModel>> GetTransaction()
        {
            var transactions = _transactionService.GetTransactions();

            if (transactions == null)
            {
                return NotFound("Can't get transaction!");
            }
            return Ok(transactions);
        }

        [MapToApiVersion("1")]
        [HttpGet("{transactionId}")]
        public ActionResult<TransactionResponseModel> GetTransactionById(int transactionId)
        {
            var transaction = _transactionService.GetTransactionById(transactionId);

            if (transaction == null)
            {
                return NotFound("Can't get transaction!");
            }
            return Ok(transaction);
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<TransactionResponseModel> CreateTransaction(CreateTransactionRequestModel transaction)
        {
            var transactionRes = _transactionService.CreateTransaction(transaction);

            if (transaction == null)
            {
                return NotFound("Can't create transaction!");
            }
            return Ok(transaction);
        }
    }
}
