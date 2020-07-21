using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SchoolManagement.ViewModels
{
    public class ManageUsersModel
    {
        public List<IdentityUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
