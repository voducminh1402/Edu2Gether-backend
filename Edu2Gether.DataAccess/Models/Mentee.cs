using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("Mentee")]
    public partial class Mentee
    {
        public Mentee()
        {
            Bookings = new HashSet<Booking>();
            Marks = new HashSet<Mark>();
        }

        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        [Required]
        [StringLength(100)]
        public string University { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(100)]
        public string Image { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(User.Mentee))]
        public virtual User IdNavigation { get; set; }
        [InverseProperty(nameof(Booking.Mentee))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(Mark.Mentee))]
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
