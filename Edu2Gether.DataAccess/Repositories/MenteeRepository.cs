using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface IMenteeRepository :IBaseRepository<Mentee>
    {
    }
    public partial class MenteeRepository :BaseRepository<Mentee>, IMenteeRepository
    {
         public MenteeRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

