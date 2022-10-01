using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories 
{

    public partial interface IBookingRepository :IBaseRepository<Booking>
    {
    }
    public partial class BookingRepository :BaseRepository<Booking>, IBookingRepository
    {
         public BookingRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

