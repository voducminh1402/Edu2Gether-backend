using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface ICourseRepository :IBaseRepository<Course>
    {

    }
    public partial class CourseRepository :BaseRepository<Course>, ICourseRepository
    {
         public CourseRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

