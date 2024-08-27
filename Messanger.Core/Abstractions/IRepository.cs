using Messanger.Core.Models;

namespace Messanger.DataAccess.Repository
{
    public interface IRepository<in T> where T : class
    {
        Task<int> Add(T data);
        Task<int> Delete(int id);
        Task<List<T>> Get();
        Task<int> Update(int id, string username, string password, string email);
        Task<bool> ValidateUser(string username, string password);
    }
}