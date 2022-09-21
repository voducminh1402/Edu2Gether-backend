using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("Course")]
    public partial class Course
    {
        public Course()
        {
            Bookings = new HashSet<Booking>();
            Marks = new HashSet<Mark>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Detail { get; set; }
        [Column("VideoURL")]
        [StringLength(100)]
        public string VideoUrl { get; set; }
        [Required]
        [StringLength(100)]
        public string Image { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal Discount { get; set; }
        public int? Capacity { get; set; }
        [Required]
        [Column("ClassURL")]
        [StringLength(100)]
        public string ClassUrl { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal EstimateHour { get; set; }
        public int SubjectId { get; set; }
        [Required]
        [StringLength(50)]
        public string MentorId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [Column(TypeName = "date")]
        public DateTime? PublishDate { get; set; }
        [Required]
        [StringLength(10)]
        public string IsActived { get; set; }
        [StringLength(50)]
        public string Approver { get; set; }
        public int? ApproveStatus { get; set; }

        [ForeignKey(nameof(MentorId))]
        [InverseProperty("Courses")]
        public virtual Mentor Mentor { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Courses")]
        public virtual Subject Subject { get; set; }
        [InverseProperty(nameof(Booking.Course))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(Mark.Course))]
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
