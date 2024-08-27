using Messanger.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.DataAccess.Repository
{
    public class ChatRepository : IRepository<Chat>
    {
        public Task<int> Add(Chat user)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> Get()
        {
            throw new NotImplementedException();
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
