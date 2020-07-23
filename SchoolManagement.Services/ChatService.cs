using SchoolManagement.Common;
using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModels.Chat;
using SchoolManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManagement.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            this.chatRepository = chatRepository;
        }

        public ActionMessage Create(string roomName)
        {
            var response = new ActionMessage();

            var dbChat = chatRepository.GetByName(roomName);

            if (dbChat != null)
            {
                response.Error = $"Chat room {roomName} already exists !";
            }

            var chat = new Chat()
            {
                Name = roomName
            };

            chatRepository.Add(chat);

            return response;
        }

        public List<ChatroomViewModel> GetAll()
        {
            var dbChats = chatRepository.GetAll();
            return dbChats.Select(x => x.ToChatroomViewModel()).ToList();
        }

        public ChatroomViewModel GetById(int chatroomId)
        {
            var dbChat = chatRepository.GetById(chatroomId);
            return dbChat.ToChatroomViewModel();
        }
    }
}
