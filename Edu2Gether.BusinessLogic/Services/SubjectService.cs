using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Subject;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface ISubjectService {
        SubjectResponseModel GetSubjectById(int id);
        List<SubjectResponseModel> GetSubjects();
        List<SubjectResponseModel> GetSubjectByMajor(int majorId);

        SubjectResponseModel CreateSubject(CreateSubjectRequestModel subject);
    }

    public class SubjectService : ISubjectService {

        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public SubjectResponseModel CreateSubject(CreateSubjectRequestModel subject)
        {
            Subject subjectRequest = _mapper.Map<Subject>(subject);

            var addedSubject = _subjectRepository.Create(subjectRequest);
            _subjectRepository.Save();

            return _mapper.Map<SubjectResponseModel>(addedSubject);

        }

        public SubjectResponseModel GetSubjectById(int id)
        {
            var subjects = _subjectRepository.Get();

            var result = subjects.SingleOrDefault(x => x.Id == id);

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<SubjectResponseModel>(result);
        }

        public List<SubjectResponseModel> GetSubjectByMajor(int majorId)
        {
            var subjects = _subjectRepository.Get().Where(x => x.MajorId == majorId);

            List<SubjectResponseModel> returnSubject = new List<SubjectResponseModel>();

            foreach (var subject in subjects)
            {
                returnSubject.Add(_mapper.Map<SubjectResponseModel>(subject));
            }

            return returnSubject;
        }

        public List<SubjectResponseModel> GetSubjects()
        {
            var subjects = _subjectRepository.Get();

            List<SubjectResponseModel> returnSubject = new List<SubjectResponseModel>();

            foreach (var subject in subjects)
            {
                returnSubject.Add(_mapper.Map<SubjectResponseModel>(subject));
            }

            return returnSubject;
        }
    }

}
