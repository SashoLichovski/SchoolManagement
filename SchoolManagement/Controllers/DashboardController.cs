using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin, Professor")]
        public IActionResult AdminMenu()
        {
            return View();
        }

        public IActionResult ActionMessage(ActionMessage actionMessage)
        {
            return View(actionMessage);
        }
    }
}