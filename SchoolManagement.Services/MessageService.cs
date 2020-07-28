using Microsoft.AspNetCore.Identity;
using SchoolManagement.Common;
using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModels.Chat;
using System;
using System.Threading.Tasks;

namespace SchoolManagement.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;
        private readonly UserManager<User> userManager;

        public MessageService(IMessageRepository messageRepository, UserManager<User> userManager)
        {
            this.messageRepository = messageRepository;
            this.userManager = userManager;
        }

        public async Task<MessageViewModel> Create(string username, int chatroomId, string text)
        {
            User user = await userManager.FindByNameAsync(username);
            var message = new Message()
            {
                Text = text,
                ChatId = chatroomId,
                CreatedBy = username,
                DatePosted = DateTime.Now,
                UserImage = user.UserImage,
            };
            await messageRepository.Add(message);
            return message.ToMessageViewModel();
        }
    }
}
