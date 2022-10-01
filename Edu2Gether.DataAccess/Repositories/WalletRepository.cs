using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface IWalletRepository :IBaseRepository<Wallet>
    {
    }
    public partial class WalletRepository :BaseRepository<Wallet>, IWalletRepository
    {
         public WalletRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

