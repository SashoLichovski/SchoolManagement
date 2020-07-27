using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModels;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;
        private readonly UserManager<User> userManager;

        public RoleController(IRoleService roleService, UserManager<User> userManager)
        {
            this.roleService = roleService;
            this.userManager = userManager;
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string rolename)
        {
            if (!string.IsNullOrEmpty(rolename))
            {
                ActionMessage response = await roleService.Create(rolename);
                return RedirectToAction("ActionMessage", "Dashboard", response);
            }
            return View();
        }

        public async Task<IActionResult> AddRole(string roleName, string userId)
        {
            await roleService.GiveUserRole(roleName, userId);
            return RedirectToAction("ManageUsers", "User");
        }

        public async Task<IActionResult> RemoveRole(string roleName, string userId)
        {
            await roleService.RemoveUserRole(roleName, userId);
            User currentUser = await userManager.GetUserAsync(User);
            
            if (currentUser.Id == userId && roleName == "Admin")
            {
                return RedirectToAction("Logout", "Auth");
            }

            return RedirectToAction("ManageUsers", "User");
        }
    }
}