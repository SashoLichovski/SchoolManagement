using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModels.Chat;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IChatService chatService;
        private readonly IMessageService messageService;

        public ChatController(IChatService chatService, IMessageService messageService)
        {
            this.chatService = chatService;
            this.messageService = messageService;
        }

        public IActionResult JoinRoom(int chatroomId)
        {
            var model = chatService.GetRoomModel(chatroomId);
            return View(model);
        }

        public IActionResult CreateRoom() => View();

        [HttpPost]
        public IActionResult CreateRoom(string roomName)
        {
            if (string.IsNullOrEmpty(roomName))
            {
                return RedirectToAction("ActionMessage", "Dashboard", new { Error = "Room name is required" });
            }
            var resposne = chatService.Create(roomName);
            if (string.IsNullOrEmpty(resposne.Error))
            {
                return RedirectToAction("JoinRoom");
            }
            else
            {
                return RedirectToAction("ActionMessage", "Dashboard", resposne);
            }
        }
    }
}
