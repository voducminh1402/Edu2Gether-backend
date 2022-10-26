using Edu2Gether.BusinessLogic.ServiceModels.ViewModels;
using Edu2Gether.BusinessLogic.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu2Gether.Presentation.Controllers
{
    [ApiController]
    [EnableCors("AllowAnyOrigins")]
    [ApiVersion("1")]
    [Route("api/v1/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [MapToApiVersion("1")]
        [HttpPost("login")]
        public async Task<ActionResult> LoginWithEmail(string token, string firebaseToken)
        {
            var loginResult = await _authenticationService.LoginByEmail(token, firebaseToken);

            return Ok(loginResult);
        }
    }
}
