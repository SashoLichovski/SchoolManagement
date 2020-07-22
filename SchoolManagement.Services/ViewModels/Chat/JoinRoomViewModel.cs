using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Services.ViewModels.Chat
{
    public class JoinRoomViewModel
    {
        public List<ChatroomViewModel> Chatrooms { get; set; }
        public int ChatroomId { get; set; }
    }
}
