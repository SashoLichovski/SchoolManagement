using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;
using System.Security.Claims;

namespace SchoolManagement.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IChatService chatService;

        public ChatController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        public IActionResult JoinRoom(int chatroomId)
        {
            var model = chatService.GetRoomModel(chatroomId);
            return View(model);
        }

        public IActionResult CreateRoom() => View();

        [HttpPost]
        public IActionResult CreateRoom(string roomName, string roomType)
        {
            if (string.IsNullOrEmpty(roomName))
            {
                return RedirectToAction("ActionMessage", "Dashboard", new { Error = "Room name is required" });
            }
            var response = new ActionMessage();

            Enums.ChatType.TryParse(roomType, out Enums.ChatType result);
            if (result == Enums.ChatType.Private)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                response = chatService.CreatePrivate(roomName, result, userId);
            }
            else
            {
                response = chatService.CreatePublic(roomName);
            }

            if (string.IsNullOrEmpty(response.Error))
            {
                return RedirectToAction("JoinRoom");
            }
            else
            {
                return RedirectToAction("ActionMessage", "Dashboard", response);
            }
        }
    }
}
