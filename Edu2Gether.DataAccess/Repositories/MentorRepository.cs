using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface IMentorRepository :IBaseRepository<Mentor>
    {
    }
    public partial class MentorRepository :BaseRepository<Mentor>, IMentorRepository
    {
         public MentorRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

