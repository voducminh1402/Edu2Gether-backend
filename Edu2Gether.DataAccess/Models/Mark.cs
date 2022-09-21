using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    [Table("Mark")]
    public partial class Mark
    {
        [Key]
        public int CourseId { get; set; }
        [Key]
        [StringLength(50)]
        public string MenteeId { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("Marks")]
        public virtual Course Course { get; set; }
        [ForeignKey(nameof(MenteeId))]
        [InverseProperty("Marks")]
        public virtual Mentee Mentee { get; set; }
    }
}
