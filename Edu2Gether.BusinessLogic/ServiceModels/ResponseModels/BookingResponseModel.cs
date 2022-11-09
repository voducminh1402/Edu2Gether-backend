
using Edu2Gether.BusinessLogic.ServiceModels.ResponseModels;
using Edu2Gether.DataAccess.Models;
using System;

namespace Edu2Gether.BusinessLogic.ViewModels 
{

    public class BookingResponseModel {
        public int Id { get; set; }
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
        public CourseResponseModel Course { get; set; }
        public MenteeResponseModel Mentee { get; set; }
    }

}
