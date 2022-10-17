
using System;

namespace Edu2Gether.BusinessLogic.ViewModels 
{

    public class SlotResponseModel {
        public int Id { get; set; }
        public TimeSpan SlotStart { get; set; }
        public TimeSpan SlotEnd { get; set; }
        public DateTime Day { get; set; }
        public string DayInWeek { get; set; }
        public int Duration { get; set; }
        public string MentorId { get; set; }
        public bool IsFree { get; set; }
    }

}
