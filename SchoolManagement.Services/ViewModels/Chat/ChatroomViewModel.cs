using SchoolManagement.Data;
using System.Collections.Generic;

namespace SchoolManagement.Services.ViewModels.Chat
{
    public class ChatroomViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Enums.ChatType Type { get; set; }
        public List<MessageViewModel> Messages { get; set; }
        public List<string> UserId { get; set; }
    }
}
