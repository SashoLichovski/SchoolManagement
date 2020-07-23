using Microsoft.Extensions.Configuration;
using SchoolManagement.Common;
using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModels.Chat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;
        private readonly IConfiguration configuration;
        private readonly IChatService chatService;

        public MessageService(IMessageRepository messageRepository, IConfiguration configuration,IChatService chatService)
        {
            this.messageRepository = messageRepository;
            this.configuration = configuration;
            this.chatService = chatService;
        }

        public async Task<MessageViewModel> Create(string username, int chatroomId, string text)
        {
            if (chatroomId == 0)
            {
                //chatroomId = 1;
                var defaultRoomName = configuration["DefaultChatroom"];
                var chatRoom = chatService.GetByName(defaultRoomName);
                chatroomId = chatRoom.Id;
            }
            var message = new Message()
            {
                Text = text,
                ChatId = chatroomId,
                CreatedBy = username,
                DatePosted = DateTime.Now,
            };
            await messageRepository.Add(message);
            return message.ToMessageViewModel();
        }
    }
}
