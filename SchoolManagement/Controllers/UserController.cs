using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data;
using SchoolManagement.Helpers;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModels;
using SchoolManagement.Services.ViewModels.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        public UserController(IUserService userService, UserManager<User> userManager)
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
        public async Task<IActionResult> Register(InputRegisterModel model, string userImage)
        {
            if (ModelState.IsValid)
            {
                byte[] image = ImageToByteConverter.Convert(userImage);
                ActionMessage response = await userService.CreateAccount(model, image);
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
            User currentUser = await userManager.GetUserAsync(User);
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

        [Authorize]
        public async Task<IActionResult> Edit (string userId)
        {
            AccountDetailsModel model = await userService.GetById(userId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AccountDetailsModel model, List<IFormFile> UserImage)
        {
            if (ModelState.IsValid)
            {
                ActionMessage response = await userService.UpdateAsync(model, UserImage);
                return RedirectToAction("ActionMessage", "Dashboard", response);
            }
            return View(model);
        }
    }
}
