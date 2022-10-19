
namespace Edu2Gether.BusinessLogic.ViewModels 
{

    public class PaymentResponseModel {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string PaymentType { get; set; }
        public string FailReason { get; set; }
    }

}
