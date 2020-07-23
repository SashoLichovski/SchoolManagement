using SchoolManagement.Services.ViewModels.Chat;
using SchoolManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Services.Interfaces
{
    public interface IChatService
    {
        ActionMessage Create(string roomName);
        List<ChatroomViewModel> GetAll();
        ChatroomViewModel GetById(int chatroomId);
    }
}
