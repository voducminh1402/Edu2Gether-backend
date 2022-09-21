using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("Wallet")]
    public partial class Wallet
    {
        public Wallet()
        {
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal Amount { get; set; }
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Wallets")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Transaction.Wallet))]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
