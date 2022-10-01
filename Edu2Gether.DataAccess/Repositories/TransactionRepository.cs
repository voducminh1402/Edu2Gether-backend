using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface ITransactionRepository :IBaseRepository<Transaction>
    {
    }
    public partial class TransactionRepository :BaseRepository<Transaction>, ITransactionRepository
    {
         public TransactionRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

