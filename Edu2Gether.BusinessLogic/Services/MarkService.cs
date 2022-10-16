using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Mark;
using Edu2Gether.BusinessLogic.ServiceModels.ResponseModels;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface IMarkService {
        MarkResponseModel MarkCourse(CreateMarkRequestModel markModel);
        MarkResponseModel UnMarkCourse(UpdateMarkRequestModel markModel);
        List<CourseResponseModel> GetCourseMarkedByUser(string userId);
    }

    public class MarkService : IMarkService {

        private readonly IMarkRepository _markRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public MarkService(IMarkRepository markRepository, IMapper mapper, ICourseRepository courseRepository)
        {
            _markRepository = markRepository;
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public List<CourseResponseModel> GetCourseMarkedByUser(string menteeId)
        {
            List<Mark> markTmp = _markRepository.Get().Where(x => x.MenteeId.Equals(menteeId)).ToList();
            List<Course> courseQuery = _courseRepository.Get().ToList();
            List<Course> courseTmp = new List<Course>();

            foreach (var mark in markTmp)
            {
                foreach (var course in courseQuery)
                {
                    if (mark.CourseId == course.Id)
                    {
                        courseTmp.Add(course);
                    }
                }
            }

            return _mapper.Map<List<CourseResponseModel>>(courseTmp);
        }

        public MarkResponseModel MarkCourse(CreateMarkRequestModel markModel)
        {
            var markCreated = _markRepository.Create(_mapper.Map<Mark>(markModel));
            _markRepository.Save();

            if (markCreated == null)
            {
                throw new Exception("Can't create mark!");
            }

            return _mapper.Map<MarkResponseModel>(markCreated);
        }

        public MarkResponseModel UnMarkCourse(UpdateMarkRequestModel markModel)
        {
            _markRepository.Delete(_mapper.Map<Mark>(markModel));
            _markRepository.Save();

            var markChecked = _markRepository
                            .Get()
                            .Where(x => x.CourseId == markModel.CourseId && x.MenteeId.Equals(markModel.MenteeId));

            if (markChecked != null)
            {
                return _mapper.Map<MarkResponseModel>(markChecked);
            }

            return null;
        }
    }

}
