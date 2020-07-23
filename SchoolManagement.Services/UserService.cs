using Microsoft.AspNetCore.Identity;
using SchoolManagement.Common;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<ActionMessage> CreateAccount(InputRegisterModel model)
        {
            ActionMessage response = new ActionMessage();

            IdentityUser dbUser = await userManager.FindByNameAsync(model.Username);

            if(dbUser == null)
            {
                IdentityUser user = new IdentityUser();
                user.Email = model.Email;
                user.UserName = model.Username;

                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    response.Message = "Account successfully created";
                }
            }
            else
            {
                response.Error = "Create failed!! Username already exists";
            }

            return response;
        }

        public async Task DeleteAccount(string userId)
        {
            IdentityUser user = await userManager.FindByIdAsync(userId);

            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
        }

        public ManageUsersModel GetAll()
        {
            ManageUsersModel model = new ManageUsersModel()
            {
                Users = userManager.Users.ToList(),
                Roles = roleManager.Roles.ToList(),
            };
            return model;
        }

        public async Task<AccountDetailsModel> GetById(string userId)
        {
            IdentityUser user = await userManager.FindByIdAsync(userId);
            return user.ToDetailsModel();
        }
    }
}