using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("Role")]
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string RoleName { get; set; }

        [InverseProperty(nameof(User.Role))]
        public virtual ICollection<User> Users { get; set; }
    }
}
