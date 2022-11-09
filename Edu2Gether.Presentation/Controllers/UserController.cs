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
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [MapToApiVersion("1")]
        [HttpPost("{userId}/change-role")]
        public ActionResult<UserResponseModel> GetUserByWallet(string userId)
        {
            UserResponseModel user = _userService.ChangeRoleToMentor(userId);

            if (user == null)
            {
                return NotFound("Can't change role of user!");
            }
            return Ok(user);
        }
    }
}
