using Edu2Gether.BusinessLogic.RequestModels.Major;
using Edu2Gether.BusinessLogic.ServiceModels.ResponseModels;
using Edu2Gether.BusinessLogic.Services;
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
    [EnableCors("AllowAnyOrigins")]
    [ApiVersion("1")]
    [Route("api/v1/majors")]
    public class MajorController : ControllerBase
    {
        private readonly IMajorService _majorService;

        public MajorController(IMajorService majorService)
        {
            _majorService = majorService;
        }

        [MapToApiVersion("1")]
        [HttpGet("{majorId}")]
        public ActionResult<MajorResponseModel> GetMajorById(int majorId)
        {
            var major = _majorService.GetMajorById(majorId);

            if (major == null)
            {
                return NotFound("Not found major with this id");
            }

            return major;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<MajorResponseModel>> GetMajors()
        {
            return _majorService.GetMajors();
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<MajorResponseModel> CreateMajor(CreateMajorRequestModel major)
        {
            return _majorService.CreateMajor(major);
        }

    }
}
