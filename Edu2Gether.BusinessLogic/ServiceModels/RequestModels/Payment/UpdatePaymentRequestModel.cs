
namespace Edu2Gether.BusinessLogic.RequestModels.Payment 
{

   public class UpdatePaymentRequestModel {
        public int Id { get; set; }
        public string Status { get; set; }
        public string FailReason { get; set; }
    }

}
