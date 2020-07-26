using Microsoft.Extensions.Configuration;
using SchoolManagement.Common;
using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModels.Chat;
using SchoolManagement.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository chatRepository;
        private readonly IConfiguration configuration;

        public ChatService(IChatRepository chatRepository, IConfiguration configuration)
        {
            this.chatRepository = chatRepository;
            this.configuration = configuration;
        }

        public ActionMessage CreatePrivate(string roomName, Enums.ChatType result, string userId)
        {
            var response = new ActionMessage();

            var chat = new Chat()
            {
                ChatType = result,
                Name = roomName,
            };
            chatRepository.Add(chat);


            var chatUser = new ChatUser()
            {
                UserId = userId,
                ChatId = chatRepository.GetByName(roomName).Id
            };

            chatRepository.AddRelation(chatUser);

            return response;
        }

        public ActionMessage CreatePublic(string roomName)
        {

            var response = new ActionMessage();

            var dbChat = chatRepository.GetByName(roomName);

            if (dbChat != null)
            {
                response.Error = $"Chat room {roomName} already exists !";
            }

            var chat = new Chat()
            {
                Name = roomName,
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

        public ChatroomViewModel GetByName(string defaultRoomName)
        {
            return chatRepository.GetByName(defaultRoomName).ToChatroomViewModel();
        }

        public JoinRoomViewModel GetRoomModel(int chatroomId)
        {
            var modelList = GetAll();
            var model = new JoinRoomViewModel()
            {
                Chatrooms = modelList
            };
            if (chatroomId != 0)
            {
                model.ChatroomId = chatroomId;
            }
            else
            {
                model.ChatroomId = GetByName(configuration["DefaultChatroom"]).Id;
            }
            return model;
        }
    }
}
