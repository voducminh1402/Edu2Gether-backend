using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("Subject")]
    public partial class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Detail { get; set; }
        [StringLength(100)]
        public string Image { get; set; }
        public int? MajorId { get; set; }

        [ForeignKey(nameof(MajorId))]
        [InverseProperty("Subjects")]
        public virtual Major Major { get; set; }
        [InverseProperty(nameof(Course.Subject))]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
