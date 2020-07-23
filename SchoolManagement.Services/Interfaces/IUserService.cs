using SchoolManagement.ViewModels;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<ActionMessage> CreateAccount(InputRegisterModel model);
        ManageUsersModel GetAll();
        Task DeleteAccount(string userId);
        Task<AccountDetailsModel> GetById(string userId);
    }
}