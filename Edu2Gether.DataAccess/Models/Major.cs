using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("Major")]
    public partial class Major
    {
        public Major()
        {
            MentorMajors = new HashSet<MentorMajor>();
            Subjects = new HashSet<Subject>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Detail { get; set; }
        [StringLength(100)]
        public string Image { get; set; }

        [InverseProperty(nameof(MentorMajor.Major))]
        public virtual ICollection<MentorMajor> MentorMajors { get; set; }
        [InverseProperty(nameof(Subject.Major))]
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
