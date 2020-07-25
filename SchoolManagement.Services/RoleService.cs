using Microsoft.AspNetCore.Identity;
using SchoolManagement.Data;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;
using System.Threading.Tasks;

namespace SchoolManagement.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<ActionMessage> Create(string rolename)
        {
            ActionMessage response = new ActionMessage();

            IdentityRole dbRole = await roleManager.FindByNameAsync(rolename);

            if(dbRole == null)
            {
                IdentityRole role = new IdentityRole();
                role.Name = rolename;

                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    response.Message = "Role Successfully Created";
                }
            }
            else
            {
                response.Error = "Create Failed! Role already exists";
            }
            return response;
        }

        public async Task GiveUserRole(string roleName, string userId)
        {
            User user = await userManager.FindByIdAsync(userId);
            await userManager.AddToRoleAsync(user, roleName);
        }

        public async Task RemoveUserRole(string roleName, string userId)
        {
            User user = await userManager.FindByIdAsync(userId);
            await userManager.RemoveFromRoleAsync(user, roleName);
        }
    }
}
