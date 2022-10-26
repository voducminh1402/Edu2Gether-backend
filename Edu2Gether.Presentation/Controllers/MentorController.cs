using Edu2Gether.BusinessLogic.RequestModels.Mentor;
using Edu2Gether.BusinessLogic.Services;
using Edu2Gether.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Edu2Gether.Presentation.Controllers
{
    [ApiController]
    [EnableCors("AllowAnyOrigins")]
    [ApiVersion("1")]
    [Route("api/v1/mentors")]
    public class MentorController
    {
        private IMentorService _mentorService;

        public MentorController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<MentorResponseModel>> GetMentors()
        {
            return _mentorService.GetMentors(); ;
        }

        [MapToApiVersion("1")]
        [HttpGet("{mentorId}")]
        public ActionResult<MentorResponseModel> GetMentorById(string mentorId)
        {
            var mentor = _mentorService.GetMentorById(mentorId);

            if (mentor == null)
            {
                throw new Exception("Can't found mentor with this id");
            }

            return mentor;
        }

        [MapToApiVersion("1")]
        [HttpGet("rating/{mentorId}")]
        public ActionResult<decimal> GetRatingByMentorId(string mentorId)
        {
            decimal mentor = _mentorService.GetMentorRating(mentorId);

            if (mentor == null)
            {
                throw new Exception("Can't found mentor with this id");
            }

            return mentor;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<MentorResponseModel> CreateMentor(CreateMentorRequestModel mentor)
        {
            var mentorAdded = _mentorService.CreateMentor(mentor);

            if (mentorAdded == null)
            {
                throw new Exception("Can't create mentor with this id");
            }

            return mentorAdded;
        }

        [MapToApiVersion("1")]
        [HttpPatch]
        public ActionResult<MentorResponseModel> UpdateMentor(UpdateMentorRequestModel mentor)
        {
            var mentorUpdated = _mentorService.UpdateMentor(mentor);

            if (mentorUpdated == null)
            {
                throw new Exception("Can't create mentor with this id");
            }

            return mentorUpdated;
        }

        [MapToApiVersion("1")]
        [HttpPost("change-status")]
        public ActionResult<MentorResponseModel> ChangeStatusMentor(int status, string mentorId)
        {
            var mentorChanged = _mentorService.ChangeStatusMentor(status, mentorId);

            if (mentorChanged == null)
            {
                throw new Exception("Can't change mentor status with this id");
            }

            return mentorChanged;
        }
    }
}
