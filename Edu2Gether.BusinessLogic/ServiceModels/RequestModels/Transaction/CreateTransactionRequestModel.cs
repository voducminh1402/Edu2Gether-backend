
using System;

namespace Edu2Gether.BusinessLogic.RequestModels.Transaction 
{

   public class CreateTransactionRequestModel {
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int PaymentId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public int WalletId { get; set; }
    }

}
