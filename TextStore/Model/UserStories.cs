using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStore.Model
{
    public class UserStories : DbItem
    {
        public int UserId { get; set; }
        public Story Story { get; set; }
        public byte Rating { get; set; }
        public bool IsFavorite { get; set; }

        public UserStories() { }

        public UserStories(User user, Story story, byte rating = 0, bool isPrivate = false)
        {
            UserId = user.Id;
            Story = story;
            Rating = rating;
        }
    }
}
