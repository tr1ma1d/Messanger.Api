using Messanger.Core.Models;
using Messanger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.DataAccess.Repository
{
    public class PersonalChatRepository : IRepository<PersonalChat>
    {
        private readonly MessangerDbContext context;
        public PersonalChatRepository(MessangerDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Add(PersonalChat data)
        {
            var personalEntity = new PersonalChatEntity()
            {
                user1_id = data.User1,
                user2_id = data.User2,
            };
            await context.personalchats.AddAsync(personalEntity);
            await context.SaveChangesAsync();
            Console.WriteLine($"THE USER: {personalEntity.user1_id} create chat with {personalEntity.user2_id}");
            return personalEntity.id;
        }

        public async Task<int> Delete(int id)
        {
            await context.personalchats.Where(x => x.id == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<List<PersonalChat>> Get()
        {
            var personalChatEntity = await context.personalchats
                .AsNoTracking()
                .ToListAsync();
            
            var personalsChats = personalChatEntity
                .Select(u => PersonalChat.Create(u.user1_id, u.user2_id).personalChat)
                .ToList();

            return personalsChats;
        }

        public Task<int> Update(int id, string username, string password, string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
