using SchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Repositories.Interfaces
{
    public interface IChatRepository
    {
        void Add(Chat chat);
        Chat GetByName(string roomName);
        List<Chat> GetAll();
        Chat GetById(int chatroomId);
        void AddRelation(ChatUser chatUser);
    }
}
