using System;
using System.Collections.Generic;
using System.Text;

namespace TextStore.Model
{
    public class User : DbItem
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Secret { get; set; }

        public User() { }

        public User(string login, string email)
        {
            Login = login;
            Email = email;
        }
    }
}
