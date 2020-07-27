using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Services.ViewModels.Chat
{
    public class AddPeopleViewModel
    {
        public List<string> Usernames { get; set; }
        public int ChatroomId { get; set; }
    }
}
