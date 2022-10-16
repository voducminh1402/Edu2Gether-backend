
using Edu2Gether.BusinessLogic.ServiceModels.ResponseModels;

namespace Edu2Gether.BusinessLogic.ViewModels 
{

    public class SubjectResponseModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }   
        public int? MajorId { get; set; }
        public MajorResponseModel Major { get; set; }
    }

}
