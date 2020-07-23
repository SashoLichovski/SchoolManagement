using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Services.ViewModels.Chat
{
    public class MessageViewModel
    {
        public string Text { get; set; }
        public string CreatedBy { get; set; }
        public int ChatId { get; set; }
        public DateTime DatePosted { get; set; }

    }
}
