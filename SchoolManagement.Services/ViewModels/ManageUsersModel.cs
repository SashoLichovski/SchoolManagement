using Microsoft.AspNetCore.Identity;
using SchoolManagement.Data;
using System.Collections.Generic;

namespace SchoolManagement.ViewModels
{
    public class ManageUsersModel
    {
        public List<User> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
