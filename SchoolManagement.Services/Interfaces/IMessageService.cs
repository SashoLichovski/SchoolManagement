using SchoolManagement.Services.ViewModels.Chat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IMessageService
    {
        Task<MessageViewModel> Create(string username, int chatroomId, string text);
    }
}
