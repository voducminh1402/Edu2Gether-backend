
namespace Edu2Gether.BusinessLogic.ViewModels 
{

    public class UserResponseModel {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IsActived { get; set; }
        public int RoleId { get; set; }
        public bool IsSystemAdmin { get; set; }
    }

}
