using Edu2Gether.BusinessLogic.RequestModels.Mentee;
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
    [Route("api/v1/mentees")]
    public class MenteeController : ControllerBase
    {
        private IMenteeService _menteeService;

        public MenteeController(IMenteeService menteeService)
        {
            _menteeService = menteeService;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<MenteeResponseModel>> GetMentees()
        {
            return _menteeService.GetMentees();
        }

        [MapToApiVersion("1")]
        [HttpGet("{menteeId}")]
        public ActionResult<MenteeResponseModel> GetMenteeById(string menteeId)
        {
            var mentee = _menteeService.GetMenteeById(menteeId);

            if (mentee == null)
            {
                throw new Exception("Can't found mentee with this id");
            }
            return mentee;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<MenteeResponseModel> CreateMentee(CreateMenteeRequestModel mentee)
        {
            var menteeAdded = _menteeService.CreateMentee(mentee);

            if (menteeAdded == null)
            {
                return NotFound("Can't create mentee with this id");
            }

            return menteeAdded;
        }

        [MapToApiVersion("1")]
        [HttpPatch]
        public ActionResult<MenteeResponseModel> UpdateMentee(UpdateMenteeRequestModel mentee)
        {
            var menteeUpdated = _menteeService.UpdateMentee(mentee);

            if (menteeUpdated == null)
            {
                return NotFound("Can't update mentee with this id");
            }

            return menteeUpdated;
        }

        [MapToApiVersion("1")]
        [HttpPost("change-status")]
        public ActionResult<MenteeResponseModel> ChangeStatusMentee(string status, string menteeId)
        {
            var menteeChanged = _menteeService.ChangeStatusMentee(status, menteeId);

            if (menteeChanged == null)
            {
                return NotFound("Can't change mentee status with this id");
            }

            return menteeChanged;
        }
    }
}
