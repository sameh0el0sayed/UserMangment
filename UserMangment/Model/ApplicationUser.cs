using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace UserMangment.Model
{
    public class ApplicationUser:IdentityUser
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)] 
        public string LastName { get; set; }

        [MaxLength(300)]
        public Byte[] ProfilePicture { get; set; }
    }
}
