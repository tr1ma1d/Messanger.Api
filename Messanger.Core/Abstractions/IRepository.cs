using Messanger.Core.Models;

namespace Messanger.DataAccess.Repository
{
    public interface IRepository
    {
        Task<int> Add(User user);
        Task<int> Delete(int id);
        Task<List<User>> Get();
        Task<int> Update(int id, string username, string password, string email);
    }
}