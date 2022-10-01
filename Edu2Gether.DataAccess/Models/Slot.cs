using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("Slot")]
    public partial class Slot
    {
        public Slot()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public int Id { get; set; }
        public TimeSpan SlotStart { get; set; }
        public TimeSpan SlotEnd { get; set; }
        [Column(TypeName = "date")]
        public DateTime Day { get; set; }
        [Required]
        [StringLength(50)]
        public string DayInWeek { get; set; }
        public int Duration { get; set; }
        [Required]
        [StringLength(50)]
        public string MentorId { get; set; }

        [ForeignKey(nameof(MentorId))]
        [InverseProperty("Slots")]
        public virtual Mentor Mentor { get; set; }
        [InverseProperty(nameof(Booking.Slot))]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
