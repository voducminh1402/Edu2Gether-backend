using Edu2Gether.BusinessLogic.RequestModels.Course;
using Edu2Gether.BusinessLogic.ServiceModels.ResponseModels;
using Edu2Gether.BusinessLogic.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Edu2Gether.Presentation.Controllers
{

    [ApiController]
    [EnableCors("AllowAnyOrigins")]
    [ApiVersion("1")]
    [Route("api/v1/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [MapToApiVersion("1")]
        [HttpGet("{courseId}")]
        public ActionResult<CourseResponseModel> GetCourseById(string courseId)
        {
            var course = _courseService.GetCourseById(courseId);

            if (course == null)
            {
                return NotFound("Not found course with this id");
            }

            return course;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<CourseResponseModel>> GetCourses()
        {
            var courses = _courseService.GetCourses();

            if (courses == null)
            {
                return NotFound("Not found any courses");
            }

            return courses;
        }

        [MapToApiVersion("1")]
        [HttpGet("{mentorId}")]
        public ActionResult<List<CourseResponseModel>> GetCourseByMentor(string mentorId)
        {
            var courses = _courseService.GetCourseByMentor(mentorId);

            if (courses == null)
            {
                return NotFound("Not found course with this mentor");
            }

            return courses;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<CourseResponseModel> CreateCourse(CreateCourseRequestModel course)
        {
            var courseCreated = _courseService.CreateCourse(course);

            if (courseCreated == null)
            {
                return NotFound("Can't create this course!");
            }

            return courseCreated;
        }

        [MapToApiVersion("1")]
        [HttpPatch]
        public ActionResult<CourseResponseModel> UpdateCourse(UpdateCourseRequestModel course)
        {
            var courseUpdated = _courseService.UpdateCourse(course);

            if (courseUpdated == null)
            {
                return NotFound("Can't update this course!");
            }

            return courseUpdated;
        }

        [MapToApiVersion("1")]
        [HttpPost("{courseId}")]
        public ActionResult<CourseResponseModel> DeleteCourse(string courseId)
        {
            var courseDeleted = _courseService.DeleteCourse(courseId);

            if (courseDeleted == null)
            {
                return NotFound("Can't create this course!");
            }

            return courseDeleted;
        }

        [MapToApiVersion("1")]
        [HttpGet("{subjectId}")]
        public ActionResult<List<CourseResponseModel>> GetCourseBySubject(int subjectId)
        {
            var courses = _courseService.GetCourseBySubject(subjectId);

            if (courses == null)
            {
                return NotFound("Not found any course with this subject");
            }

            return courses;
        }

    }
}
