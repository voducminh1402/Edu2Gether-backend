using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Wallets = new HashSet<Wallet>();
        }

        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        [Required]
        [StringLength(10)]
        public string IsActived { get; set; }
        public int RoleId { get; set; }
        public bool IsSystemAdmin { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Users")]
        public virtual Role Role { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual Mentee Mentee { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual Mentor Mentor { get; set; }
        [InverseProperty(nameof(Wallet.User))]
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
