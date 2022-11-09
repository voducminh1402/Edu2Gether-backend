using Edu2Gether.BusinessLogic.RequestModels.Course;
using Edu2Gether.BusinessLogic.ServiceModels.ResponseModels;
using Edu2Gether.BusinessLogic.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Edu2Gether.Presentation.Controllers
{

    [ApiController]
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
        public ActionResult<CourseResponseModel> GetCourseById(int courseId)
        {
            var course = _courseService.GetCourseById(courseId);

            if (course == null)
            {
                return NotFound("Not found course with this id");
            }

            return course;
        }

        [MapToApiVersion("1")]
        [HttpGet("course")]
        public ActionResult<List<CourseResponseModel>> GetCourseByName([FromQuery] string name)
        {
            var courses = _courseService.GetCourseByName(name);

            if (courses == null)
            {
                throw new Exception("Can't found mentor with this name");
            }

            return courses;
        }

        [MapToApiVersion("1")]
        [HttpGet("major")]
        public ActionResult<List<CourseResponseModel>> GetCourseByMajorName([FromQuery] string majorName)
        {
            var courses = _courseService.GetCourseByMajorName(majorName);

            if (courses == null)
            {
                throw new Exception("Can't found mentor with this major name");
            }

            return courses;
        }

        [MapToApiVersion("1")]
        [HttpGet("course/on-going")]
        public ActionResult<List<CourseResponseModel>> GetOnGoingCourse()
        {
            var courses = _courseService.GetOnGoingCourse();

            if (courses == null)
            {
                throw new Exception("Can't found courses");
            }

            return courses;
        }

        [MapToApiVersion("1")]
        [HttpGet("course/completed")]
        public ActionResult<List<CourseResponseModel>> GetCompletedCourse()
        {
            var courses = _courseService.GetCompletedCourse();

            if (courses == null)
            {
                throw new Exception("Can't found courses");
            }

            return courses;
        }

        [MapToApiVersion("1")]
        [HttpGet("get-course-subject-name/{subjectName}")]
        public ActionResult<List<CourseResponseModel>> GetCourseBySubjectName(string subjectName)
        {
            var courses = _courseService.GetCourseBySubjectName(subjectName);

            if (courses == null)
            {
                throw new Exception("Can't found courses");
            }

            return courses;
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
        [HttpGet("mentors/{mentorId}")]
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
        public ActionResult<CourseResponseModel> CreateCourse([FromForm] CreateCourseRequestModel course)
        {
            var courseCreated = _courseService.CreateCourse(course);

            if (courseCreated == null)
            {
                return NotFound("Can't create this course!");
            }

            return StatusCode(201, courseCreated);
        }

        [MapToApiVersion("1")]
        [HttpPatch]
        public ActionResult<CourseResponseModel> UpdateCourse([FromForm] UpdateCourseRequestModel course)
        {
            var courseUpdated = _courseService.UpdateCourse(course);

            if (courseUpdated == null)
            {
                return NotFound("Can't update this course!");
            }

            return StatusCode(200, courseUpdated);
        }

        [MapToApiVersion("1")]
        [HttpPost("{courseId}")]
        public ActionResult<CourseResponseModel> DeleteCourse([FromForm] string courseId)
        {
            var courseDeleted = _courseService.DeleteCourse(courseId);

            if (courseDeleted == null)
            {
                return NotFound("Can't create this course!");
            }

            return StatusCode(200, courseDeleted);
        }

        [MapToApiVersion("1")]
        [HttpGet("subjects/{subjectId}")]
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
