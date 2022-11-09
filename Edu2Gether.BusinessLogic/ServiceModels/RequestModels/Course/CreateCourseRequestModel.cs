
using System;

namespace Edu2Gether.BusinessLogic.RequestModels.Course 
{

   public class CreateCourseRequestModel {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string VideoUrl { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int? Capacity { get; set; }
        public string ClassUrl { get; set; }
        public decimal EstimateHour { get; set; }
        public int SubjectId { get; set; }
        public string MentorId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? PublishDate { get; set; }
        public string IsActived { get; set; }
        public string Approver { get; set; }
        public int? ApproveStatus { get; set; }
    }

}
