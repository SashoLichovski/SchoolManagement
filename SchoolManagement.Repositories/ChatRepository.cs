using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManagement.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly SchoolManagementDbContext context;

        public ChatRepository(SchoolManagementDbContext context)
        {
            this.context = context;
        }

        public void Add(Chat chat)
        {
            context.Chats.Add(chat);
            context.SaveChanges();
        }

        public List<Chat> GetAll()
        {
            return context.Chats
                .Include(x => x.Messages)
                .ToList();
        }

        public Chat GetById(int chatroomId)
        {
            return context.Chats
                .Include(x => x.Messages)
                .FirstOrDefault(x => x.Id.Equals(chatroomId));
        }

        public Chat GetByName(string roomName)
        {
            return context.Chats.FirstOrDefault(x => x.Name.Equals(roomName));
        }
    }
}
