using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UserMangment.ViewModels
{
    public class UserRoleVM
    {
        public string UserID { get; set; } 
        public string UserName { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }=new List<string>();
    }
}
