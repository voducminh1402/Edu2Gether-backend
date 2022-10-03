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
}
