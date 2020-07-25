using Microsoft.AspNetCore.Identity;

namespace SchoolManagement.Data
{
    public class User : IdentityUser
    {
        public byte[] UserImage { get; set; }
    }
}
