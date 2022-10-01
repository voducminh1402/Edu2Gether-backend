using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface IMentorMajorRepository :IBaseRepository<MentorMajor>
    {
    }
    public partial class MentorMajorRepository :BaseRepository<MentorMajor>, IMentorMajorRepository
    {
         public MentorMajorRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

