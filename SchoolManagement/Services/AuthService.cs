using Microsoft.AspNetCore.Identity;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.ViewModels;
using System.Threading.Tasks;

namespace SchoolManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<ActionMessage> SignInAsync(InputLoginModel model)
        {
            ActionMessage response = new ActionMessage();
            IdentityUser user = await userManager.FindByEmailAsync(model.Email);

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