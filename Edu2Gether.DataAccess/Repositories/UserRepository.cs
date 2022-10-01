using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface IUserRepository :IBaseRepository<User>
    {
    }
    public partial class UserRepository :BaseRepository<User>, IUserRepository
    {
         public UserRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

