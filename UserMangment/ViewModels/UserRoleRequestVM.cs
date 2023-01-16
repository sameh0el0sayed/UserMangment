namespace UserMangment.ViewModels
{
    public class UserRoleRequestVM
    {

        public string UserID { get; set; }
        public string UserName { get; set; }
        public List<RoleVM> Roles { get; set; }
    }
}
