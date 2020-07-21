using SchoolManagement.ViewModels;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ActionMessage> SignInAsync(InputLoginModel model);
        Task SignOutAsync();
    }
}
