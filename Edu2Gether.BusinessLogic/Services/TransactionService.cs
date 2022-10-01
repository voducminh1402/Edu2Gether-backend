using Edu2Gether.DataAccess.Repositories;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface ITransactionService {
    
    }

    public class TransactionService : ITransactionService {

      private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

    }

}
