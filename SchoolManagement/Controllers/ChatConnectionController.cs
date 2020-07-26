using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SchoolManagement.Hubs;
using SchoolManagement.Migrations;
using SchoolManagement.Services.Interfaces;

namespace SchoolManagement.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ChatConnectionController : Controller
    {
        private readonly IHubContext<ChatHub> chat;
        private readonly IMessageService messageService;

        public ChatConnectionController(IHubContext<ChatHub> chat, IMessageService messageService)
        {
            this.chat = chat;
            this.messageService = messageService;
        }

        [HttpPost("[action]/{connectionId}/{chatroomName}")]
        public async Task<IActionResult> JoinRoom(string connectionId, string chatroomName)
        {
            await chat.Groups.AddToGroupAsync(connectionId, chatroomName);
            return Ok();
        }

        [HttpPost("[action]/{connectionId}/{chatroomName}")]
        public async Task<IActionResult> LeaveRoom(string connectionId, string chatroomName)
        {
            await chat.Groups.RemoveFromGroupAsync(connectionId, chatroomName);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendMessage(string text, int chatroomId, string chatroomName)
        {
            var username = User.Identity.Name;
            var msg = await messageService.Create(username, chatroomId, text);
            await chat.Clients.Group(chatroomName).SendAsync("ReceiveMessage", new { 
                Text = msg.Text,
                CreatedBy = msg.CreatedBy,
                DatePosted = msg.DatePosted.ToString("MMMM-dd, hh:mm tt")
            });
            return Ok();
        }
    }
}
