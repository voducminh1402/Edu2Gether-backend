using AutoMapper;
using Edu2Gether.BusinessLogic.Commons;
using Edu2Gether.BusinessLogic.RequestModels.Course;
using Edu2Gether.BusinessLogic.ServiceModels.ResponseModels;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Edu2Gether.BusinessLogic.Services 
{
    public interface ICourseService {
        List<CourseResponseModel> GetCourses();
        List<CourseResponseModel> GetCourseByMentor(string mentorId);
        CourseResponseModel GetCourseById(int id);
        CourseResponseModel CreateCourse(CreateCourseRequestModel course);
        CourseResponseModel UpdateCourse(UpdateCourseRequestModel course);
        CourseResponseModel DeleteCourse(string id);
        List<CourseResponseModel> GetCourseBySubject(int subjectId);
    }

    public class CourseService : ICourseService {

        private readonly ICourseRepository _courseRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMajorRepository _majorRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper, ISubjectRepository subjectRepository, IMajorRepository majorRepository)
        {
            _courseRepository = courseRepository;
            _subjectRepository = subjectRepository;
            _majorRepository = majorRepository;
            _mapper = mapper;
        }

        public CourseResponseModel CreateCourse(CreateCourseRequestModel course)
        {
            var courseAdded = _courseRepository.Create(_mapper.Map<Course>(course));
            _courseRepository.Save();

            return _mapper.Map<CourseResponseModel>(courseAdded);
        }

        public CourseResponseModel DeleteCourse(string id)
        {
            var courseDelete = _courseRepository.Get().Where(x => x.Id.Equals(id)).FirstOrDefault();

            if (courseDelete != null)
            {
                courseDelete.IsActived = CourseConst.REMOVED;
                return _mapper.Map<CourseResponseModel>(courseDelete);
            }

            return null;
        }

        public CourseResponseModel GetCourseById(int id)
        {
            var course = _courseRepository.Get().Where(x => x.Id == id).FirstOrDefault();

            if (course != null)
            {
                var courseRes = _mapper.Map<CourseResponseModel>(course);
                courseRes.Subject = _mapper.Map<SubjectResponseModel>(_subjectRepository.Get().Where(x => x.Id == courseRes.SubjectId).FirstOrDefault());
                courseRes.Major = _mapper.Map<MajorResponseModel>(_majorRepository.Get().Where(x => x.Id == courseRes.Subject.MajorId).FirstOrDefault());
                return courseRes;
            }

            return null;
        }

        public List<CourseResponseModel> GetCourseBySubject(int subjectId)
        {
            var courses = _courseRepository.Get().Where(x => x.SubjectId == subjectId).ToList();

            if (courses != null)
            {
                return _mapper.Map<List<CourseResponseModel>>(courses);
            }

            return null;
        }

        public List<CourseResponseModel> GetCourseByMentor(string mentorId)
        {
            var courses = _courseRepository.Get().Where(x => x.MentorId.Equals(mentorId)).ToList();

            if (courses != null)
            {
                return _mapper.Map<List<CourseResponseModel>>(courses);
            }

            return null;
        }

        public List<CourseResponseModel> GetCourses()
        {
            var courses = _courseRepository.Get().ToList();

            if (courses != null)
            {
                var courseRes = _mapper.Map<List<CourseResponseModel>>(courses);
                List<CourseResponseModel> returnCourse = new List<CourseResponseModel>();

                foreach (var item in courseRes)
                {
                    item.Subject = _mapper.Map<SubjectResponseModel>(_subjectRepository.Get().Where(x => x.Id == item.SubjectId).FirstOrDefault());
                    item.Major = _mapper.Map<MajorResponseModel>(_majorRepository.Get().Where(x => x.Id == item.Subject.MajorId).FirstOrDefault());
                    returnCourse.Add(item);
                }

                return returnCourse;
            }

            return null;
        }

        public CourseResponseModel UpdateCourse(UpdateCourseRequestModel course)
        {
            var courseTmp = _mapper.Map<Course>(course);
            var courseUpdated = _courseRepository.Update(courseTmp);
            _courseRepository.Save();

            if (courseUpdated != null)
            {
                return _mapper.Map<CourseResponseModel>(courseUpdated);
            }

            return null;
        }
    }

}
