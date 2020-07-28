using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SchoolManagement.Data
{
    public class User : IdentityUser
    {
        public byte[] UserImage { get; set; }
        public List<ChatUser> Chats { get; set; }
    }
}
