
using System;

namespace Edu2Gether.BusinessLogic.RequestModels.Booking 
{

   public class CreateBookingRequestModel {
        public string MentorId { get; set; }
        public string MenteeId { get; set; }
        public int CourseId { get; set; }
        public DateTime BookingTime { get; set; }
        public string Status { get; set; }
        public decimal CoursePrice { get; set; }
        public string CanceledBy { get; set; }
        public string CanceledReason { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
        public DateTime? FeedbackTime { get; set; }
        public int SlotId { get; set; }
    }

}
