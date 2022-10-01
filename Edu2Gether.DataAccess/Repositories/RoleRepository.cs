using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface IRoleRepository :IBaseRepository<Role>
    {
    }
    public partial class RoleRepository :BaseRepository<Role>, IRoleRepository
    {
         public RoleRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

