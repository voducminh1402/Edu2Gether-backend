using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("Payment")]
    public partial class Payment
    {
        public Payment()
        {
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        public int Id { get; set; }
        public int BookingId { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal TotalPrice { get; set; }
        [Required]
        [StringLength(10)]
        public string Status { get; set; }
        [Required]
        [StringLength(50)]
        public string PaymentType { get; set; }
        [StringLength(150)]
        public string FailReason { get; set; }

        [ForeignKey(nameof(BookingId))]
        [InverseProperty("Payments")]
        public virtual Booking Booking { get; set; }
        [InverseProperty(nameof(Transaction.Payment))]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
