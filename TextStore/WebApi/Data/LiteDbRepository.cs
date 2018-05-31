using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextStore.Model;
using LiteDB;
using TextStore.WebApi.Model;

namespace TextStore.WebApi.Data
{
    public class LiteDbRepository : IRepository
    {
        private static string stories = "stories";
        private static string users = "users";
        private static string userStories = "user_stories";

        public void Init()
        {
            using (var db = GetLiteDb())
            {
                db.GetCollection<User>(users).EnsureIndex(x => x.Email);
                db.GetCollection<User>(users).EnsureIndex(x => x.Secret);
                db.GetCollection<User>(users).EnsureIndex(x => x.Login);
                db.GetCollection<Story>(stories).EnsureIndex(x => x.Category);
                db.GetCollection<UserStories>(userStories).EnsureIndex(x => x.UserId);
            }

            BsonMapper.Global.Entity<User>()
                .Id(x => x.Id);

            BsonMapper.Global.Entity<Story>()
                .Id(x => x.Id);

            BsonMapper.Global.Entity<UserStories>()
                .DbRef(x => x.Story, stories);
        }

        public IEnumerable<Story> GetStories(int page, int count)
        {
            using (var db = GetRepository())
            {
                return db.Query<Story>().ToArray();                   
            }
        }

        public IEnumerable<Story> GetStories()
        {
            using (var db = GetLiteDb())
            {
                var r = db.GetCollection<Story>().FindAll();
                return r.ToArray();
            }
        }

        public IEnumerable<UserStories> GetUserStories(User user, int page, int count)
        {
            using (var db = GetRepository())
            {
                return db.Query<UserStories>()
                        .Where(u => u.UserId == user.Id)
                        .Include(x => x.Story).ToEnumerable();
            }
        }

        public User GetUser(string loginOrEmail)
        {
            using (var db = GetRepository())
            {
                var user = db.Query<User>().Where(u => u.Login == loginOrEmail).SingleOrDefault();
                if (user == null)
                    user = db.Query<User>().Where(u => u.Email == loginOrEmail).SingleOrDefault();

                return user;
            }
        }

        public User GetUserBySercret(string secret)
        {
            using (var db = GetRepository())
            {
                return db.Query<User>().Where(u => u.Secret == secret).Single();
            }
        }

        private LiteRepository GetRepository()
        {
            return new LiteRepository(Configuration.GetConfiguration().LiteDb);
        }

        private LiteDatabase GetLiteDb()
        {
            return new LiteDatabase(Configuration.GetConfiguration().LiteDb);
        }

        public void Save<T>(T data) where T : DbItem
        {
            using (var db = GetRepository())
            {
                db.Upsert<T>(data);
            }
        }

        public void Delete<T>(int id) where T : DbItem
        {
            if (typeof(T) == typeof(User)
                || typeof(T) == typeof(Story))
            {
                T data = GetById<T>(id);
                data.IsVisible = false;
                Save(data);
            }          
        }

        public T GetById<T>(int id) where T: DbItem
        {
            using (var db = GetRepository())
            {
                return db.Query<T>().Where(x => x.Id == id).SingleOrDefault();
            }
        }
    }



}
