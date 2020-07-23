using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public void Create(string username, int chatroomId, string text)
        {
            if (chatroomId == 0)
            {
                chatroomId = 1;
            }
            var message = new Message()
            {
                Text = text,
                ChatId = chatroomId,
                CreatedBy = username,
                DatePosted = DateTime.Now,
            };
            messageRepository.Add(message);
        }
    }
}
