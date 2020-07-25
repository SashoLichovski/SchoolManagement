using Microsoft.AspNetCore.Identity;
using SchoolManagement.Data;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;
using System.Threading.Tasks;

namespace SchoolManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<ActionMessage> SignInAsync(InputLoginModel model)
        {
            ActionMessage response = new ActionMessage();
            User user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    response.Message = "Successfully logged in!!";
                }
                else
                {
                    response.Error = "Login Failed!!";
                }
            }
            else
            {
                response.Error = "User Doesn`t exist";
            }
            return response;
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}