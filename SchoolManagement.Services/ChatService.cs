using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Common;
using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModels.Chat;
using SchoolManagement.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository chatRepository;
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;

        public ChatService(IChatRepository chatRepository, IConfiguration configuration, UserManager<User> userManager)
        {
            this.chatRepository = chatRepository;
            this.configuration = configuration;
            this.userManager = userManager;
        }

        public async Task AddPerson(int chatroomId, string username)
        {
            User user = await userManager.FindByNameAsync(username);
            var userId = user.Id;
            CreateChatUser(userId, chatroomId);
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

            var chatroomId = chatRepository.GetByName(roomName).Id;

            CreateChatUser(userId, chatroomId);

            return response;
        }

        private void CreateChatUser(string userId, int chatroomId)
        {
            var chatUser = new ChatUser()
            {
                UserId = userId,
                ChatId = chatroomId
            };

            chatRepository.AddRelation(chatUser);
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

        public List<ChatUser> GetChatUsers(int chatroomId)
        {
            return chatRepository.GetChatUsers(chatroomId);
        }
    }
}
