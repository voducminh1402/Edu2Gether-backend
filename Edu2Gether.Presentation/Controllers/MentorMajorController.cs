using Edu2Gether.BusinessLogic.RequestModels.MentorMajor;
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
    [Route("api/v1/mentors-majors")]
    public class MentorMajorController : ControllerBase
    {
        private readonly IMentorMajorService _mentorMajorService;

        public MentorMajorController(IMarkService markService, IMentorMajorService mentorMajorService)
        {
            _mentorMajorService = mentorMajorService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<MentorMajorResponseModel> CreateMentorMajor(CreateMentorMajorRequestModel mentorMajor)
        {
            var mentorMajorCreated = _mentorMajorService.CreateMentorMajor(mentorMajor);

            if (mentorMajorCreated == null)
            {
                return NotFound("Can't create mentor with this major!");
            }

            return mentorMajorCreated;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<MentorMajorResponseModel> DeleteMentorMajor(UpdateMentorMajorRequestModel mentorMajor)
        {
            var mentorMajorDeleted = _mentorMajorService.DeleteMentorMajor(mentorMajor);

            if (mentorMajorDeleted != null)
            {
                return NotFound("Can't delete this mentor and major!");
            }
            else
            {
                return Ok("Delete mentor major successfully");
            }
        }

        [MapToApiVersion("1")]
        [HttpGet("{majorId}/mentors")]
        public ActionResult<List<MentorResponseModel>> GetMentorByMajor(int majorId)
        {
            return _mentorMajorService.GetMentorByMajor(majorId);
        }
    }
}
