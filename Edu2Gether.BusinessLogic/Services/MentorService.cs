using AutoMapper;
using Edu2Gether.BusinessLogic.Commons;
using Edu2Gether.BusinessLogic.RequestModels.Mentor;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface IMentorService {
        List<MentorResponseModel> GetMentors();
        MentorResponseModel GetMentorById(string id);
        MentorResponseModel CreateMentor(CreateMentorRequestModel mentor);
        MentorResponseModel UpdateMentor(UpdateMentorRequestModel mentorUpdate);
        MentorResponseModel ChangeStatusMentor(int statusId, string mentorId);
        decimal GetMentorRating(string mentorId); 
    }

    public class MentorService : IMentorService {

        private readonly IMentorRepository _mentorRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public MentorService(IMentorRepository mentorRepository, IMapper mapper, IBookingRepository bookingRepository)
        {
            _mentorRepository = mentorRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public List<MentorResponseModel> GetMentors()
        {
            List<Mentor> returnList = _mentorRepository.Get().ToList();
            return _mapper.Map<List<MentorResponseModel>>(returnList);
        }

        public MentorResponseModel GetMentorById(string id)
        {
            Mentor mentor = _mentorRepository.Get().SingleOrDefault(x => x.Id.Equals(id));
            return _mapper.Map<MentorResponseModel>(mentor);
        }

        public MentorResponseModel CreateMentor(CreateMentorRequestModel mentor)
        {
            Mentor mentorTmp = _mapper.Map<Mentor>(mentor);
            mentorTmp.ApproveStatusId = (int) MentorStatus.Pending;

            Mentor mentorCreated = _mentorRepository.Create(mentorTmp);
            _mentorRepository.Save();

            if (mentorCreated == null)
            {
                throw new Exception("Can't create mentor! Something error!");
            }

            return _mapper.Map<MentorResponseModel>(mentorCreated);
        }

        public MentorResponseModel UpdateMentor(UpdateMentorRequestModel mentorUpdate)
        {
            Mentor mentorTmp = _mapper.Map<Mentor>(mentorUpdate);
            mentorTmp.ApproveStatusId = (int)MentorStatus.Pending;

            Mentor mentorCreated = _mentorRepository.Update(mentorTmp);
            _mentorRepository.Save();

            if (mentorCreated == null)
            {
                throw new Exception("Can't update mentor! Something error!");
            }

            return _mapper.Map<MentorResponseModel>(mentorCreated);
        }

        public MentorResponseModel ChangeStatusMentor(int statusId, string mentorId)
        {
            Mentor mentor = _mentorRepository.Get().Where(x => x.Id.Equals(mentorId)).FirstOrDefault();

            if (mentor != null)
            {
                mentor.ApproveStatusId = statusId;
                Mentor mentorReturn = _mentorRepository.Update(mentor);
                _mentorRepository.Save();
                return _mapper.Map<MentorResponseModel>(mentorReturn);
            }

            return null;
        }

        public decimal GetMentorRating(string mentorId)
        {
            int numberRating = _bookingRepository.Get().Where(x => x.MentorId.Equals(mentorId)).Select(y => y.Id).Count();
            int totalRating = _bookingRepository.Get().Where(x => x.MentorId.Equals(mentorId) && x.Rating.HasValue).Sum(x => x.Rating.Value);

            if (totalRating <= 0 || numberRating <= 0)
            {
                return -1;
            }

            return Math.Round((decimal) numberRating / totalRating, 2);
        }
    }

}
