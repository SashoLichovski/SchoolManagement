using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModels.Chat;
using System.Security.Claims;

namespace SchoolManagement.Controllers
{
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
            var list = chatService.GetAll();
            var model = new JoinRoomViewModel()
            {
                Chatrooms = list
            };
            if (chatroomId != 0)
            {
                model.ChatroomId = chatroomId;
            }
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

        [HttpPost]
        public IActionResult CreateMessage(int chatroomId, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return RedirectToAction("JoinRoom", new { ChatroomId = chatroomId });
            }
            else
            {
                string username = User.Identity.Name;
                messageService.Create(username, chatroomId, text);
                return RedirectToAction("JoinRoom", new { ChatroomId = chatroomId });
            }
        }
    }
}
