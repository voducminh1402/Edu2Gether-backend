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
    [Route("api/v1/wallets")]
    public class WalletController : ControllerBase
    {
        private IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [MapToApiVersion("1")]
        [HttpGet("{walletId}/user")]
        public ActionResult<UserResponseModel> GetUserByWallet(int walletId)
        {
            UserResponseModel user = _walletService.GetUserByWallet(walletId);

            if (user == null)
            {
                return NotFound("Can't get user!");
            }
            return Ok(user);
        }

        [MapToApiVersion("1")]
        [HttpGet("user/{userId}")]
        public ActionResult<WalletResponseModel> GetWalletByUser(string userId)
        {
            WalletResponseModel wallet = _walletService.GetWalletByUser(userId);

            if (wallet == null)
            {
                return NotFound("Can't get wallet!");
            }
            return Ok(wallet);
        }
    }
}
