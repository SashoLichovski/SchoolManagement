using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult ChatRooms()
        {
            return View();
        }
    }
}
