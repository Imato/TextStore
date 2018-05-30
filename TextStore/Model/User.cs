using System;
using System.Collections.Generic;
using System.Text;

namespace TextStore.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Secret { get; set; }
    }
}
