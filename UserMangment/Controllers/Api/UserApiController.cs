using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserMangment.Helper;
using UserMangment.Models;
using UserMangment.ViewModels;

namespace UserMangment.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = ApplicationRoleName.Admin)]

    public class UserApiController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserApiController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost] 
        public async Task<IActionResult> EditUser(EditUserVM requestData)
        {




            return Ok();
        }

        [HttpGet]
        [Route("GetUser")] 
        public async Task<IActionResult> GetUser()
        {




            return Ok();
        }

    }
}
