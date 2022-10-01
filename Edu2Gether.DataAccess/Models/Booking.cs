using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("Booking")]
    public partial class Booking
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string MentorId { get; set; }
        [Required]
        [StringLength(50)]
        public string MenteeId { get; set; }
        public int CourseId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BookingTime { get; set; }
        [Required]
        [StringLength(10)]
        public string Status { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal CoursePrice { get; set; }
        [StringLength(50)]
        public string CanceledBy { get; set; }
        [StringLength(500)]
        public string CanceledReason { get; set; }
        public int? Rating { get; set; }
        [StringLength(500)]
        public string Comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FeedbackTime { get; set; }
        public int SlotId { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("Bookings")]
        public virtual Course Course { get; set; }
        [ForeignKey(nameof(MenteeId))]
        [InverseProperty("Bookings")]
        public virtual Mentee Mentee { get; set; }
        [ForeignKey(nameof(SlotId))]
        [InverseProperty("Bookings")]
        public virtual Slot Slot { get; set; }
        [InverseProperty(nameof(Payment.Booking))]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
