using Edu2Gether.BusinessLogic.RequestModels.Major;
using Edu2Gether.BusinessLogic.RequestModels.Subject;
using Edu2Gether.BusinessLogic.ServiceModels.ResponseModels;
using Edu2Gether.BusinessLogic.Services;
using Edu2Gether.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Edu2Gether.Presentation.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/subjects")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [MapToApiVersion("1")]
        [HttpGet("{subjectId}")]
        public ActionResult<SubjectResponseModel> GetSubjectById(int subjectId)
        {
            var subject = _subjectService.GetSubjectById(subjectId);

            if (subject == null)
            {
                return NotFound("Not found subject with this id");
            }

            return subject;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<SubjectResponseModel>> GetSubjects()
        {
            return _subjectService.GetSubjects();
        }

        [MapToApiVersion("1")]
        [HttpGet("majors/{majorId}")]
        public ActionResult<List<SubjectResponseModel>> GetSubjectByMajorId(int majorId)
        {
            return _subjectService.GetSubjectByMajor(majorId);
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<SubjectResponseModel> CreateSubject(CreateSubjectRequestModel subject)
        {
            return _subjectService.CreateSubject(subject);
        }

    }
}
