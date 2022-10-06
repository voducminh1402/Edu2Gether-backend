
namespace Edu2Gether.BusinessLogic.RequestModels.Subject 
{

   public  class CreateSubjectRequestModel {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public int? MajorId { get; set; }
    }

}
