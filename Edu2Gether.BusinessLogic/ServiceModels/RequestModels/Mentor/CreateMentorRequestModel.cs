
namespace Edu2Gether.BusinessLogic.RequestModels.Mentor 
{

   public class CreateMentorRequestModel {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Qualification { get; set; }
        public string Evidence { get; set; }
        public string Job { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public string WebsiteUrl { get; set; }
        public int? ApproveStatusId { get; set; }
    }

}
