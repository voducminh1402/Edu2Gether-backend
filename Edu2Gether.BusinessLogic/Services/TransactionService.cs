using AutoMapper;
using Edu2Gether.BusinessLogic.RequestModels.Transaction;
using Edu2Gether.BusinessLogic.ViewModels;
using Edu2Gether.DataAccess.Models;
using Edu2Gether.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Edu2Gether.BusinessLogic.Services 
{

    public interface ITransactionService {
        List<TransactionResponseModel> GetTransactionByUser(string userId);
        List<TransactionResponseModel> GetTransactions();
        TransactionResponseModel GetTransactionById(int id);
        TransactionResponseModel CreateTransaction(CreateTransactionRequestModel transaction);
    }

    public class TransactionService : ITransactionService {

        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper, IWalletRepository walletRepository)
        {
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public TransactionResponseModel CreateTransaction(CreateTransactionRequestModel transaction)
        {
            var transactionCreate = _mapper.Map<Transaction>(transaction);

            Transaction transactionAdded = _transactionRepository.Create(transactionCreate);

            if (transactionAdded == null)
            {
                return null;
            }

            return _mapper.Map<TransactionResponseModel>(transactionAdded);

        }

        public TransactionResponseModel GetTransactionById(int id)
        {
            var transaction = _transactionRepository.Get().Where(x => x.Id == id).FirstOrDefault();

            if (transaction == null)
            {
                return null;
            }
            return _mapper.Map<TransactionResponseModel>(transaction);
        }

        public List<TransactionResponseModel> GetTransactionByUser(string userId)
        {
            var transactions = _transactionRepository.Get().ToList();
            List<Transaction> returnTransactionTmp = new List<Transaction>();
            List<Transaction> returnTransactions = new List<Transaction>();

            foreach (var item in transactions)
            {
                item.Wallet = _walletRepository.Get().Where(x => x.Id == item.WalletId).FirstOrDefault();
                returnTransactionTmp.Add(item);
            }

            foreach (var itemReturn in returnTransactionTmp)
            {
                if (itemReturn.Wallet.UserId.Equals(userId))
                {
                    returnTransactions.Add(itemReturn);
                }
            }

            if (transactions == null)
            {
                return null;
            }
            return _mapper.Map<List<TransactionResponseModel>>(returnTransactions);
        }

        public List<TransactionResponseModel> GetTransactions()
        {
            var transactions = _transactionRepository.Get().ToList();

            if (transactions == null)
            {
                return null;
            }
            return _mapper.Map<List<TransactionResponseModel>>(transactions);
        }
    }

}
