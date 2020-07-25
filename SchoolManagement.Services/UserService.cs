using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolManagement.Common;
using SchoolManagement.Data;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<ActionMessage> CreateAccount(InputRegisterModel model)
        {
            ActionMessage response = new ActionMessage();

            User dbUser = await userManager.FindByNameAsync(model.Username);

            if(dbUser == null)
            {
                User user = new User();
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
            User user = await userManager.FindByIdAsync(userId);

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
            User user = await userManager.FindByIdAsync(userId);
            return user.ToDetailsModel();
        }

        public async Task<ActionMessage> UpdateAsync(AccountDetailsModel model, List<IFormFile> userImage)
        {
            ActionMessage response = new ActionMessage();
            User user = await userManager.FindByIdAsync(model.UserId);

            byte[] image = await ConvertImageToByteArrayAsync(userImage);

            if(user != null)
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.UserImage = image;

               IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    response.Message = "Update Successful";
                }
            }
            else
            {
                response.Error = "Update Failed";
            }
            return response; 
        }

        private async Task<byte[]> ConvertImageToByteArrayAsync(List<IFormFile> userImage)
        {
            MemoryStream stream= new MemoryStream();
            foreach(var item in userImage)
            {
                await item.CopyToAsync(stream);
            }
            return stream.ToArray();
        }
    }
}