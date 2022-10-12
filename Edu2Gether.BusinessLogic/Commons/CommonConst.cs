using System.ComponentModel.DataAnnotations;

namespace Edu2Gether.BusinessLogic.Commons
{
    public enum UserRole
    {
        [Display(Name = "System Admin")]
        SystemAdmin = 1,
        [Display(Name = "Admin")]
        Admin = 2,
        [Display(Name = "Mentor")]
        Mentor = 3,
        [Display(Name = "Mentee")]
        Mentee = 4,
    }

    public enum MentorStatus
    {
        [Display(Name = "Pending")]
        Pending = 1,
        [Display(Name = "Approved")]
        Approved = 3,
        [Display(Name = "Rejected")]
        Rejected = 4,
        [Display(Name = "Removed")]
        Removed = 4,
    }
}
