using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<IdentityUser> userManager;

        public UserController(IUserService userService, UserManager<IdentityUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            InputRegisterModel model = new InputRegisterModel();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Register(InputRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ActionMessage response = await userService.CreateAccount(model);
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("ActionMessage", "Dashboard", response);
                }
                else
                {
                    return RedirectToAction("Login", "Auth"); 
                }
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ManageUsers()
        {
            ManageUsersModel model = userService.GetAll();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            IdentityUser currentUser = await userManager.GetUserAsync(User);
            await userService.DeleteAccount(userId);
            if (currentUser.Id == userId)
            {
                return RedirectToAction("Logout", "Auth");
            }
            return RedirectToAction("ManageUsers");
        }
        [Authorize]
        public async Task<IActionResult> AccountDetails(string userId)
        {
            AccountDetailsModel model = await userService.GetById(userId);
            return View(model);
        }
    }
}
