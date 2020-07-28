using Microsoft.AspNetCore.Http;
using SchoolManagement.Services.ViewModels;
using SchoolManagement.Services.ViewModels.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<ActionMessage> CreateAccount(InputRegisterModel model, byte[] image);
        ManageUsersModel GetAll();
        Task DeleteAccount(string userId);
        Task<AccountDetailsModel> GetById(string userId);
        Task<ActionMessage> UpdateAsync(AccountDetailsModel model, List<IFormFile> userImage);
        List<string> GetUsernames(int chatroomId);
    }
}