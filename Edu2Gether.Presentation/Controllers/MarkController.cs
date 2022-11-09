using Edu2Gether.BusinessLogic.RequestModels.Mark;
using Edu2Gether.BusinessLogic.ServiceModels.ResponseModels;
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
    [Route("api/v1/marks")]
    public class MarkController : ControllerBase
    {
        private readonly IMarkService _markService;

        public MarkController(IMarkService markService)
        {
            _markService = markService;
        }

        [MapToApiVersion("1")]
        [HttpPost("mark")]
        public ActionResult<MarkResponseModel> MarkCourse(CreateMarkRequestModel mark)
        {
            var markFollowed = _markService.MarkCourse(mark);

            if (markFollowed == null)
            {
                return NotFound("Can't mark this course!");
            }

            return StatusCode(200, markFollowed);
        }

        [MapToApiVersion("1")]
        [HttpGet("users/{userId}")]
        public ActionResult<List<CourseResponseModel>> GetCourseMarkedByUser(string userId)
        {
            return _markService.GetCourseMarkedByUser(userId);
        }

        [MapToApiVersion("1")]
        [HttpPost("un-mark")]
        public ActionResult<MarkResponseModel> UnMarkCourse(UpdateMarkRequestModel mark)
        {
            var markUnfollowed = _markService.UnMarkCourse(mark);

            if (markUnfollowed != null)
            {
                return NotFound("Can't unmark this course!"); 
            }
            else
            {
                return Ok($"Unmark course {mark.CourseId} successfully");
            }
            
        }

        [MapToApiVersion("1")]
        [HttpGet("check-exist")]
        public ActionResult<BaseResponseModel> CheckExistInMark([FromQuery]string menteeId, [FromQuery]int courseId)
        {
            var mark = _markService.CheckExistInMark(menteeId, courseId);

            if (mark == null)
            {
                return new BaseResponseModel
                {
                    StatusCode = 404,
                    Message = "Not Exist"
                };
            }
            return new BaseResponseModel
            {
                StatusCode = 200,
                Message = "Existed"
            };
        }
    }
}
