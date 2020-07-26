using SchoolManagement.Data;
using SchoolManagement.Services.ViewModels.Chat;
using SchoolManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Services.Interfaces
{
    public interface IChatService
    {
        ActionMessage CreatePublic(string roomName);
        ActionMessage CreatePrivate(string roomName, Enums.ChatType result, string userId);
        List<ChatroomViewModel> GetAll();
        ChatroomViewModel GetById(int chatroomId);
        ChatroomViewModel GetByName(string defaultRoomName);
        JoinRoomViewModel GetRoomModel(int chatroomId);
    }
}
