using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("Mentor")]
    public partial class Mentor
    {
        public Mentor()
        {
            Courses = new HashSet<Course>();
            MentorMajors = new HashSet<MentorMajor>();
        }

        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [Required]
        [StringLength(500)]
        public string Qualification { get; set; }
        [StringLength(100)]
        public string Evidence { get; set; }
        [Required]
        [StringLength(50)]
        public string Job { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(100)]
        public string Image { get; set; }
        [Column("WebsiteURL")]
        [StringLength(100)]
        public string WebsiteUrl { get; set; }
        public int? ApproveStatusId { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(User.Mentor))]
        public virtual User IdNavigation { get; set; }
        [InverseProperty(nameof(Course.Mentor))]
        public virtual ICollection<Course> Courses { get; set; }
        [InverseProperty(nameof(MentorMajor.Mentor))]
        public virtual ICollection<MentorMajor> MentorMajors { get; set; }
    }
}
