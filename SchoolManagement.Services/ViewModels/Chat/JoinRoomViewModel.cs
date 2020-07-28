using System.Collections.Generic;

namespace SchoolManagement.Services.ViewModels.Chat
{
    public class JoinRoomViewModel
    {
        public List<ChatroomViewModel> Chatrooms { get; set; }
        public int ChatroomId { get; set; }
        public string PublicRoomsClass { get; set; }
        public string PrivateRoomsClass { get; set; }
        public string ChatType { get; set; }
    }
}
