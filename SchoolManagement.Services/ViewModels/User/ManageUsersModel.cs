using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SchoolManagement.Services.ViewModels.User
{
    public class ManageUsersModel
    {
        public List<Data.User> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
