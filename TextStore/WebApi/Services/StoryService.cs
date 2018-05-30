using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextStore.Model;

namespace TextStore.WebApi.Services
{
    public class StoryService
    {
        public IEnumerable<Story> Get(int pageId = 0, int count = 20)
        {
            return null;
        }

        public void Add(User user, Story story)
        {

        }

        public IEnumerable<Story> GetSaved(User user, int pageId = 0, int count = 20)
        {
            return null;
        }

        public void Save(User user, Story story)
        {

        }
    }
}
