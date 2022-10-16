using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Major;
using Edu2Gether.BusinessLogic.ServiceModels.ResponseModels;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface IMajorService {
        MajorResponseModel GetMajorById(int id);
        List<MajorResponseModel> GetMajors();
        MajorResponseModel CreateMajor(CreateMajorRequestModel major);
    }

    public class MajorService : IMajorService {

        private readonly IMajorRepository _majorRepository;
        private readonly IMapper _mapper;

        public MajorService(IMajorRepository majorRepository, IMapper mapper)
        {
            _mapper = mapper;
            _majorRepository = majorRepository;
        }

        public MajorResponseModel GetMajorById(int id)
        {
            var majors = _majorRepository.Get();

            var result = majors.SingleOrDefault(x => x.Id == id);

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<MajorResponseModel>(result);
        }

        public List<MajorResponseModel> GetMajors()
        {
            var majors = _majorRepository.Get();

            List<MajorResponseModel> resultList = new List<MajorResponseModel>();

            foreach (Major major in majors) {
                resultList.Add(_mapper.Map<MajorResponseModel>(major));
            }

            return resultList;
        }

        public MajorResponseModel CreateMajor(CreateMajorRequestModel major)
        {
            var createMajor = _mapper.Map<Major>(major);

            var result = _majorRepository.Create(createMajor);
            _majorRepository.Save();

            return _mapper.Map<MajorResponseModel>(result);
        }
    }

}
