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
        IEnumerable<Story> GetStories();
        T GetById<T>(int id) where T : DbItem;
        IEnumerable<UserStories> GetUserStories(User user, int page = 0, int count = 0);
        void Save<T>(T data) where T : DbItem;
        void Delete<T>(int id) where T : DbItem;
        User GetUser(string loginOrEmail);
        User GetUserBySercret(string secret);
        void Init();
    }
}