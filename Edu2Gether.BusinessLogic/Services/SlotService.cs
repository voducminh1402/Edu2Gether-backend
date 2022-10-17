using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Slot;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface ISlotService {
        SlotResponseModel CreateSlot(CreateSlotRequestModel slot);
        void DeleteSlotByMentorAndId(MentorDateSlotRequestModel modelDelete);
        List<SlotResponseModel> GetSlotByMentorAndDate(string mentorId, DateTime date);
        bool CheckSlotExistInDay(CreateSlotRequestModel slot);
        List<SlotResponseModel> GetSlotInDay(DateTime date);

    }

    public class SlotService : ISlotService {

        private readonly ISlotRepository _slotRepository;
        private readonly IMapper _mapper;

        public SlotService(ISlotRepository slotRepository, IMapper mapper)
        {
            _slotRepository = slotRepository;
            _mapper = mapper;
        }

        public bool CheckSlotExistInDay(CreateSlotRequestModel slot)
        {
            bool slotCheck = _slotRepository.Get().Where(x => x.Day.CompareTo(slot.Day) == 0 && slot.MentorId.Equals(x.MentorId)).FirstOrDefault(null) == null;

            return slotCheck;
        }

        public SlotResponseModel CreateSlot(CreateSlotRequestModel slot)
        {
            if (CheckSlotExistInDay(slot))
            {
                return null;
            }

            var slotCreated = _slotRepository.Create(_mapper.Map<Slot>(slot));
            _slotRepository.Save();

            if (slotCreated != null)
            {
                return _mapper.Map<SlotResponseModel>(slotCreated);
            }

            return null;
        }

        public void DeleteSlotByMentorAndId(MentorDateSlotRequestModel modelDelete)
        {
            var slotDelete = _slotRepository
                            .Get()
                            .Where(x => x.MentorId.Equals(modelDelete.mentorId) && x.Day.CompareTo(modelDelete.date) == 0).FirstOrDefault();
        
            if (slotDelete != null)
            {
                _slotRepository.Delete(slotDelete);
                _slotRepository.Save();
            }
            else
            {
                throw new Exception("Can't delete this slot!");
            }
        }

        public List<SlotResponseModel> GetSlotByMentorAndDate(string mentorId, DateTime date)
        {
            var slot = _slotRepository.Get().Where(x => x.MentorId.Equals(mentorId) && x.Day.CompareTo(date) == 0).ToList();

            return _mapper.Map<List<SlotResponseModel>>(slot);
        }

        public List<SlotResponseModel> GetSlotInDay(DateTime date)
        {
            var slot = _slotRepository.Get().Where(x => x.Day.CompareTo(date) == 0).ToList();

            return _mapper.Map<List<SlotResponseModel>>(slot);
        }
    }

}
