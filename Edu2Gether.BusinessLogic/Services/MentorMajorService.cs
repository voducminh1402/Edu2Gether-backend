using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.MentorMajor;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface IMentorMajorService {
        MentorMajorResponseModel CreateMentorMajor(CreateMentorMajorRequestModel mentorMajor);
        MentorMajorResponseModel DeleteMentorMajor(UpdateMentorMajorRequestModel mentorMajor);
        List<MentorResponseModel> GetMentorByMajor(int majorId);
    }

    public class MentorMajorService : IMentorMajorService {

        private readonly IMentorMajorRepository _mentorMajorRepository;
        private readonly IMentorRepository _mentorRepository;
        private readonly IMapper _mapper;

        public MentorMajorService(IMentorMajorRepository mentormajorRepository, IMapper mapper, IMentorRepository mentorRepository)
        {
            _mentorMajorRepository = mentormajorRepository;
            _mapper = mapper;
            _mentorRepository = mentorRepository;
        }

        public MentorMajorResponseModel CreateMentorMajor(CreateMentorMajorRequestModel mentorMajor)
        {
            var mentorMajorCreated = _mentorMajorRepository.Create(_mapper.Map<MentorMajor>(mentorMajor));
            _mentorMajorRepository.Save();

            if (mentorMajorCreated == null)
            {
                throw new Exception("Can't create mentor and major!");
            }

            return _mapper.Map<MentorMajorResponseModel>(mentorMajorCreated);
        }

        public List<MentorResponseModel> GetMentorByMajor(int majorId)
        {
            List<string> mentorIdTmp = _mentorMajorRepository.Get().Where(x => x.MajorId == majorId).Select(x => x.MentorId).ToList();
            List<Mentor> mentorQuery = _mentorRepository.Get().ToList();
            List<Mentor> mentorTmp = new List<Mentor>();

            foreach (string mentorId in mentorIdTmp)
            {
                foreach (var mentor in mentorQuery)
                {
                    if (mentor.Id.Equals(mentorId))
                    {
                        mentorTmp.Add(mentor);
                    }
                }
            }

            return _mapper.Map<List<MentorResponseModel>>(mentorTmp);
        }

        public MentorMajorResponseModel DeleteMentorMajor(UpdateMentorMajorRequestModel mentorMajor)
        {
            _mentorMajorRepository.Delete(_mapper.Map<MentorMajor>(mentorMajor));
            _mentorMajorRepository.Save();

            var mentorMajorChecked = _mentorMajorRepository
                            .Get()
                            .Where(x => x.MajorId == mentorMajor.MajorId && x.MentorId.Equals(mentorMajor.MentorId));

            if (mentorMajorChecked != null)
            {
                return _mapper.Map<MentorMajorResponseModel>(mentorMajorChecked);
            }

            return null;
        }
    }

}
