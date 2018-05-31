using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextStore.Model;
using TextStore.WebApi.Infrastructure;

namespace TextStore.WebApi.Model
{
    public class Configuration
    {
        private static Configuration _config = new Configuration();

        private Configuration()
        {
            LiteDb = "./Data/TextStore.db";
            SystemUser = new User("TextStore", "App.TextStore@gmail.com");
        }
        public static Configuration GetConfiguration()
        {
            return _config;
        }

        public string LiteDb { get; }

        public User SystemUser { get; }
    }
}
