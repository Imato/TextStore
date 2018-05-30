using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStore.Model
{
    public class UserStories
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Story Story { get; set; }
        public int Rating { get; set; }
        public bool IsPrivate { get; set; }

        public UserStories() { }

        public UserStories(User user, Story story, int rating = 0, bool isPrivate = false)
        {
            UserId = user.Id;
            Story = story;
            Rating = rating;
            IsPrivate = isPrivate;
        }
    }
}
