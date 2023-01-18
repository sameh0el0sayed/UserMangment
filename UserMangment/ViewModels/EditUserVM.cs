using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UserMangment.ViewModels
{
    public class EditUserVM
    {
        
        public string UserID { get; set; }
         
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
         
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public List<RoleVM> Roles { get; set; }

    }
}
