using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextStore.WebApi.Model
{
    public class Configuration
    {
        private static Configuration _config = new Configuration();

        private Configuration()
        {
            LiteDb = "./Data/TextStore.db";
        }
        public static Configuration GetConfiguration()
        {
            return _config;
        }

        public string LiteDb { get; }
    }
}
