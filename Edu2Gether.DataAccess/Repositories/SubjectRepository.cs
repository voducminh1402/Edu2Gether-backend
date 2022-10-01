using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface ISubjectRepository :IBaseRepository<Subject>
    {
    }
    public partial class SubjectRepository :BaseRepository<Subject>, ISubjectRepository
    {
         public SubjectRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

