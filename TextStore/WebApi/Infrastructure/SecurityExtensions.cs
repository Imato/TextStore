using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextStore.Model;

namespace TextStore.WebApi.Infrastructure
{
    public static class SecurityExtensions
    {
        public static void NewSecret(this User user)
        {
            user.Secret = new Guid().ToString();
        }
    }
}
