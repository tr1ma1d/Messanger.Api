using Messanger.Core.Models;
using Messanger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messanger.DataAccess.Repository
{


    // Этот класс для того, чтобы просто получать данные и управлять ими(взаимодействие с бд)
    // 
    //
    // This is class for just get and manage thim


    public class UserRepository : IRepository
    {
        //connect with ours DataBase
        private readonly MessangerDbContext context;
        //Get context than connect database and manage him
        public UserRepository(MessangerDbContext context)
        {
            this.context = context;
        }

        //Get a collections users for authorizate || for example
        public async Task<List<User>> Get()
        {
            var userEntities = await context.users
                .AsNoTracking()
                .ToListAsync();
            var users = userEntities
                .Select(u => User.Create(u.id, u.username, u.password, u.email).User)
                .ToList(); // Возвращаю кортеж user и возвращаю как список

            return users;
        }

        //adding users to database 
        public async Task<int> Add(User user)
        {
            var userEntity = new UserEntity
            {
                id = user.id,
                username = user.username,
                password = user.password,
                email = user.email,
            };
            await context.users.AddAsync(userEntity);
            await context.SaveChangesAsync();
            Console.WriteLine($"Adding new users:  {userEntity.id}, {userEntity.username.ToUpper()}");
            return userEntity.id;
        }

        public async Task<int> Update(int id, string username, string password, string email)
        {

            // a simply metgod for update
            await context.users
                .Where(x => x.id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.username, b => username)
                    .SetProperty(b => b.password, b => password) // Corrected here
                    .SetProperty(b => b.email, b => email));

            return id;
        }

        public async Task<int> Delete(int id)
        {
            //so too delete
            await context.users
                .Where(x => x.id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
