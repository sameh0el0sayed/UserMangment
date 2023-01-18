using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserMangment.Helper;
using UserMangment.Models;
using UserMangment.ViewModels;

namespace UserMangment.Controllers
{
    [Authorize(Roles =ApplicationRoleName.Admin)]
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
          
        public async Task<IActionResult> ShowUser()
        {
             
            var users = await _userManager.Users.ToListAsync();
            var usersVM = users.Select(user => new UserRoleVM
            {
                UserID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result
            }).ToList();

            return View(usersVM);
        } 
        public async Task<IActionResult> ManageRole(string userId)
        {
            var user=await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var roles=await _roleManager.Roles.ToListAsync();
            var viewModel = new UserRoleRequestVM
            {
                UserID = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(r => new RoleVM
                {
                    RoleID = r.Id,
                    RoleName = r.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, r.Name).Result
                }).ToList()

            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRole(UserRoleRequestVM userRoleRequestVM)
        {
           
            var user = await _userManager.FindByIdAsync(userRoleRequestVM.UserID);
            if (user == null) return NotFound();

            foreach (var role in userRoleRequestVM.Roles)
            {
                 
                if (role.IsSelected) {
                    await  _userManager.AddToRoleAsync(user, role.RoleName);
                }
                else {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
            }


            return RedirectToAction(nameof(ShowUser));
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var roles = await _roleManager.Roles.ToListAsync();
            var viewModel = new EditUserVM
            {
                UserID = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = roles.Select(r => new RoleVM
                {
                    RoleID = r.Id,
                    RoleName = r.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, r.Name).Result
                }).ToList()

            };

            return View(viewModel);
        }

        [HttpPost]
         
        public async Task<IActionResult> EditUser(EditUserVM requestData)
        {

            var user = await _userManager.FindByIdAsync(requestData.UserID);
            if (user == null) return NotFound();

            user.FirstName= requestData.FirstName;  
            user.LastName= requestData.LastName;
            user.Email= requestData.Email;
            await _userManager.UpdateAsync(user);


            foreach (var role in requestData.Roles)
            {

                if (role.IsSelected)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
            }


            return RedirectToAction(nameof(ShowUser));


            return Ok();
        }


    }
}
