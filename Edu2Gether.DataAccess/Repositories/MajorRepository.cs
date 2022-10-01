using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface IMajorRepository :IBaseRepository<Major>
    {
    }
    public partial class MajorRepository :BaseRepository<Major>, IMajorRepository
    {
         public MajorRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

