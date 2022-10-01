using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface IMarkRepository :IBaseRepository<Mark>
    {
    }
    public partial class MarkRepository :BaseRepository<Mark>, IMarkRepository
    {
         public MarkRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

