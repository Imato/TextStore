using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStore.Model
{
    public class UserStories
    {
        public int UserId { get; set; }
        public int StoryId { get; set; }
        public int Rating { get; set; }
        public bool IsPrivate { get; set; }
    }
}
