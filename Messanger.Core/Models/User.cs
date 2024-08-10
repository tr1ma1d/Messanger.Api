using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Core.Models
{
    public class User
    {
        private User(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public int? id { get; private set; }
        public string username { get; } = string.Empty;
        public string password { get; } = string.Empty;
        public string email { get; } = string.Empty;

        // Создание пользователя
        public static (User User, string Error) Create(string username, string password, string email)
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                error = "Имя пользователя или пароль не могут быть пустыми";
            }

            var user = new User(username, password, email);
            return (user, error);
        }
    }

}
