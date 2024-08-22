using Messanger.Core.Models;

namespace Messanger.Services.Services
{
    public interface IUsersServices
    {
        Task<int> CreateUser(User user);
        Task<List<User>> GetAllUsers();
        Task<int> UpdateUser(int id, string username, string password, string email);
        Task<bool> ValidateUser(string username, string password);
    }
}