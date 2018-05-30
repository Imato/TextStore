using System;
using System.Collections.Generic;
using System.Text;

namespace TextStore.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Secret { get; set; }
        public bool IsActive { get; set; }
    }
}
