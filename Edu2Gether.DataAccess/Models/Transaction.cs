using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("Transaction")]
    public partial class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedTime { get; set; }
        public int PaymentId { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Status { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal Amount { get; set; }
        public int WalletId { get; set; }

        [ForeignKey(nameof(PaymentId))]
        [InverseProperty("Transactions")]
        public virtual Payment Payment { get; set; }
        [ForeignKey(nameof(WalletId))]
        [InverseProperty("Transactions")]
        public virtual Wallet Wallet { get; set; }
    }
}
