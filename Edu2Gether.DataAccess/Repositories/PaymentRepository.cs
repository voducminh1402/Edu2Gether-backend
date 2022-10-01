using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using Edu2Gether.DataAccess.Models;

namespace Edu2Gether.DataAccess.Repositories
{

    public partial interface IPaymentRepository :IBaseRepository<Payment>
    {
    }
    public partial class PaymentRepository :BaseRepository<Payment>, IPaymentRepository
    {
         public PaymentRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

