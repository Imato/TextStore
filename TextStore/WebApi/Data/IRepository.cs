using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextStore.Model;

namespace TextStore.WebApi.Data
{
    public interface IRepository
    {
        IEnumerable<Story> GetStories(int page = 0, int count = 0);
        IEnumerable<UserStories> GetUserStories(User user, int page = 0, int count = 0);
        void Save<T>(T data);
        void Delete<T>(T data);
        User GetUser(string loginOrEmail);
        User GetUserBySercret(string secret);
    }
}