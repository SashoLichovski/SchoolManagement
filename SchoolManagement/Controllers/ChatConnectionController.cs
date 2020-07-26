using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SchoolManagement.Hubs;
using SchoolManagement.Services.Interfaces;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ChatConnectionController : Controller
    {
        private readonly IHubContext<ChatHub> chat;
        private readonly IChatService chatService;
        private readonly IMessageService messageService;

        public ChatConnectionController(IHubContext<ChatHub> chat, IChatService chatService, IMessageService messageService)
        {
            this.chat = chat;
            this.chatService = chatService;
            this.messageService = messageService;
        }

        [HttpPost("[action]/{connectionId}/{chatroomId}")]
        public async Task<IActionResult> JoinRoom(string connectionId, int chatroomId)
        {
            var chatName = chatService.GetById(chatroomId).Name;
            await chat.Groups.AddToGroupAsync(connectionId, chatName);
            return Ok();
        }

        [HttpPost("[action]/{connectionId}/{chatroomId}")]
        public async Task<IActionResult> LeaveRoom(string connectionId, int chatroomId)
        {
            var chatName = chatService.GetById(chatroomId).Name;
            await chat.Groups.RemoveFromGroupAsync(connectionId, chatName);
            return Ok();
        }

        public async Task<IActionResult> SendMessage(string text, int chatroomId)
        {
            var chatName = chatService.GetById(chatroomId).Name;
            var username = User.Identity.Name;
            var msg = await messageService.Create(username, chatroomId, text);
            await chat.Clients.Group(chatName).SendAsync("ReceiveMessage", msg);
            return Ok();
        }
    }
}
