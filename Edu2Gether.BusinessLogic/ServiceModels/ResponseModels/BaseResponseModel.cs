using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu2Gether.BusinessLogic.ServiceModels.ResponseModels
{
    public class BaseResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
