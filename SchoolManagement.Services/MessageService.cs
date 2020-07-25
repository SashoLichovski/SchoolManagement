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

        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public async Task<MessageViewModel> Create(string username, int chatroomId, string text)
        {
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
