using AutoMapper;
using Edu2Gether.BusinessLogic.Commons;
using Edu2Gether.BusinessLogic.RequestModels.Mentee;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Edu2Gether.BusinessLogic.Services 
{
    public interface IMenteeService {
        List<MenteeResponseModel> GetMentees();
        MenteeResponseModel GetMenteeById(string id);
        MenteeResponseModel CreateMentee(CreateMenteeRequestModel mentee);
        MenteeResponseModel UpdateMentee(UpdateMenteeRequestModel meteeUpdate);
        MenteeResponseModel ChangeStatusMentee(string status, string mentorId);
    }

    public class MenteeService : IMenteeService {

        private readonly IMenteeRepository _menteeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public MenteeService(IMenteeRepository menteeRepository, IMapper mapper, IUserRepository userRepository)
        {
            _menteeRepository = menteeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public MenteeResponseModel ChangeStatusMentee(string status, string mentorId)
        {
            User user = _userRepository.Get().Where(x => x.Id.Equals(mentorId)).FirstOrDefault();

            if (user != null)
            {
                user.IsActived = status;
                User userReturn = _userRepository.Update(user);
                _userRepository.Save();
                Mentee mentee = _menteeRepository.Get().Where(x => x.Id.Equals(userReturn.Id)).FirstOrDefault();
                return _mapper.Map<MenteeResponseModel>(mentee);
            }

            return null;
        }

        public MenteeResponseModel CreateMentee(CreateMenteeRequestModel mentee)
        {
            Mentee menteeTmp = _mapper.Map<Mentee>(mentee);

            Mentee menteeCreated = _menteeRepository.Create(menteeTmp);
            _menteeRepository.Save();

            if (menteeCreated == null)
            {
                throw new Exception("Can't create mentor! Something error!");
            }

            return _mapper.Map<MenteeResponseModel>(menteeCreated);
        }

        public MenteeResponseModel GetMenteeById(string id)
        {
            Mentee mentee = _menteeRepository.Get().SingleOrDefault(x => x.Id.Equals(id));
            return _mapper.Map<MenteeResponseModel>(mentee);
        }

        public List<MenteeResponseModel> GetMentees()
        {
            List<Mentee> returnList = _menteeRepository.Get().ToList();
            return _mapper.Map<List<MenteeResponseModel>>(returnList);
        }

        public MenteeResponseModel UpdateMentee(UpdateMenteeRequestModel meteeUpdate)
        {
            Mentee menteeTmp = _mapper.Map<Mentee>(meteeUpdate);

            Mentee menteeUpdated = _menteeRepository.Update(menteeTmp);
            _menteeRepository.Save();

            if (menteeUpdated == null)
            {
                throw new Exception("Can't update mentor! Something error!");
            }

            return _mapper.Map<MenteeResponseModel>(menteeUpdated);
        }
    }

}
