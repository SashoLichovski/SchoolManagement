using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.ViewModels;

namespace SchoolManagement.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin, Professor")]
        public IActionResult AdminMenu() => 
            View();

        public IActionResult ActionMessage(ActionMessage actionMessage) =>
            View(actionMessage);
    }
}