using System;

namespace SchoolManagement.Services.ViewModels.Chat
{
    public class MessageViewModel
    {
        public string Text { get; set; }
        public string CreatedBy { get; set; }
        public int ChatId { get; set; }
        public DateTime DatePosted { get; set; }
        public byte[] UserImage { get; set; }
    }
}
