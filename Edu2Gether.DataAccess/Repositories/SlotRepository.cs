using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface ISlotRepository :IBaseRepository<Slot>
    {
    }
    public partial class SlotRepository :BaseRepository<Slot>, ISlotRepository
    {
         public SlotRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

