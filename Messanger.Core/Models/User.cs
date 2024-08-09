using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Core.Models
{
    public class User
    {
        private User(int id, string username, string password, string email)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
        }
        public int id { get; }
        public string username { get; } = string.Empty;
        public string password { get; } = string.Empty;
        public string email { get; } = string.Empty;
        //Просто создаем или регистрируюем пользователя 
        public static (User User, string Error) Create(int id, string username, string password, string email)
        {
            var error = string.Empty;
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                error = "username or password is empty";

            }
            var user = new User(id, username, password, email);
            return (user, error);
            
        }

    }
}
