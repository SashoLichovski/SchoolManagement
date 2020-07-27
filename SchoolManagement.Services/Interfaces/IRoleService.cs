using SchoolManagement.Services.ViewModels;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IRoleService
    {
        Task<ActionMessage> Create(string rolename);
        Task GiveUserRole(string roleName, string userId);
        Task RemoveUserRole(string roleName, string userId);
    }
}
