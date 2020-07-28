using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolManagement.Common;
using SchoolManagement.Data;
using SchoolManagement.Services.Common;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModels;
using SchoolManagement.Services.ViewModels.User;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IChatService chatService;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IChatService chatService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.chatService = chatService;
        }

        public async Task<ActionMessage> CreateAccount(InputRegisterModel model, byte[] image)
        {
            ActionMessage response = new ActionMessage();

            User dbUser = await userManager.FindByNameAsync(model.Username);

            if(dbUser == null)
            {
                User user = new User();
                user.Email = model.Email;
                user.UserName = model.Username;
                user.UserImage = image;

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

        public List<string> GetUsernames(int chatroomId)
        {
            var users = userManager.Users.ToList();

            var chatUserIds = chatService.GetChatUsers(chatroomId)
                .Select(x => x.UserId)
                .ToList();

            var usernames = users.Where(x => !chatUserIds.Contains(x.Id))
                .Select(x => x.UserName)
                .ToList();

            return usernames;
        }

        public async Task<ActionMessage> UpdateAsync(AccountDetailsModel model, List<IFormFile> userImage)
        {
            ActionMessage response = new ActionMessage();

            User user = await userManager.FindByIdAsync(model.UserId);

            bool exists = userManager.Users.Where(x => x.Id != model.UserId && x.UserName == model.UserName).Any();

            if (exists)
            {
                response.Error = $"Update Failed!!! Username {model.UserName} aleready exists ";
                return response;
            }

            byte[] image = await ByteArrayConverter.ConvertImageToByteArrayAsync(userImage);

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
    }
}