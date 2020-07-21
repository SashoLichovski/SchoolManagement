using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("AdminMenu", "Dashboard");
            }
            else
            {
                InputLoginModel model = new InputLoginModel();
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(InputLoginModel model)
        {
            if (ModelState.IsValid)
            {
                //Dodaj Logika ako userot ne postoi
                ActionMessage response = await authService.SignInAsync(model);
                return RedirectToAction("ActionMessage", "Dashboard", response);
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await authService.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}