using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Services.Interfaces
{
    public interface IMessageService
    {
        void Create(string username, int chatroomId, string text);
    }
}
