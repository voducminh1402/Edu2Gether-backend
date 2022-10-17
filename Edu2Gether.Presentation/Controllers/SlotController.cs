using Edu2Gether.BusinessLogic.RequestModels.Slot;
using Edu2Gether.BusinessLogic.Services;
using Edu2Gether.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu2Gether.Presentation.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/slots")]
    public class SlotController : ControllerBase
    {
        private ISlotService _slotService;

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<SlotResponseModel> CreateSlot(CreateSlotRequestModel slot)
        {
            var slotCreated = _slotService.CreateSlot(slot);

            if (slotCreated == null)
            {
                return NotFound("Can't choose this slot!");
            }
            return slotCreated;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult DeleteSlotByMentorAndId(MentorDateSlotRequestModel modelDelete)
        {
            _slotService.DeleteSlotByMentorAndId(modelDelete);

            return Ok("This slot was deleted!");
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<SlotResponseModel>> GetSlotByMentorAndDate(string mentorId, DateTime date)
        {
            var slots = _slotService.GetSlotByMentorAndDate(mentorId, date);

            if (slots == null)
            {
                return NotFound("Not found any slot with mentor and this day");
            }

            return slots;
        }

        [MapToApiVersion("1")]
        [HttpGet("{date}")]
        public ActionResult<List<SlotResponseModel>> GetSlotInDay(string date)
        {
            DateTime checkDate = DateTime.Parse(date);

            var slots = _slotService.GetSlotInDay(checkDate);

            if (slots == null)
            {
                return NotFound("Not found any slot in this day");
            }

            return slots;
        }
    }
}
