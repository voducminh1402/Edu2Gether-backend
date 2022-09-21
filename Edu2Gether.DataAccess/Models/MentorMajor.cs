using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("MentorMajor")]
    public partial class MentorMajor
    {
        [Key]
        [StringLength(50)]
        public string MentorId { get; set; }
        [Key]
        public int MajorId { get; set; }

        [ForeignKey(nameof(MajorId))]
        [InverseProperty("MentorMajors")]
        public virtual Major Major { get; set; }
        [ForeignKey(nameof(MentorId))]
        [InverseProperty("MentorMajors")]
        public virtual Mentor Mentor { get; set; }
    }
}
