using Messanger.Core.Models;
using Messanger.Crypto;
using Messanger.DataAccess.Repository;

namespace Messanger.Services.Services
{
    //For logical 
    //Класс для управления данными в общем сохраняет бизнес логику 
    //приложения. В общем главное, чтобы контроллеры не разростались, ибо все GG и приложения нет. 
    //Также стоит писать подробно, чтобы, а чтобы нефиг было. Читали программисты мой код и такие, а НУ РАЗ GET ALL ну значит GET ALL

    public class UsersServices : IUsersServices
    {
        private readonly IRepository repository;

        public UsersServices(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await repository.Get();
        }
        public async Task<int> CreateUser(User user)
        {
            return await repository.Add(user);
        }
        public async Task<int> UpdateUser(int id, string username, string password, string email)
        {
            return await repository.Update(id, username, password, email);
        }
        public async Task<bool> ValidateUser(string username, string password)
        {
            return await repository.ValidateUser(username, password);
        }
    }
}
