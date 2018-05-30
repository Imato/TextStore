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

        private LiteDbRepository()
        {
            BsonMapper.Global.Entity<User>()
                .Id(x => x.Id);

            BsonMapper.Global.Entity<Story>()
                .Id(x => x.Id);

            BsonMapper.Global.Entity<UserStories>()
                .DbRef(x => x.Story, stories);

            using (var db = GetLiteDb())
            {
                db.GetCollection<User>(users).EnsureIndex(x => x.Email);
                db.GetCollection<User>(users).EnsureIndex(x => x.Secret);
                db.GetCollection<User>(users).EnsureIndex(x => x.Login);
                db.GetCollection<Story>(stories).EnsureIndex(x => x.Category);
                db.GetCollection<UserStories>(userStories).EnsureIndex(x => x.UserId);
            }
        }

        public IEnumerable<Story> GetStories(int page, int count)
        {
            using (var db = GetRepository())
            {
                return db.Query<Story>(stories).ToEnumerable();                   
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

        public void Save<T>(T data)
        {
            using (var db = GetRepository())
            {
                db.Upsert<T>(data);
            }
        }

        public void Delete<T>(T data)
        {
            var u = data as User;
            if (u != null)
            {
                u.IsActive = false;
                Save(u);
            }

            var s = data as Story;
            if (s != null)
            {
                s.IsVisible = false;
                Save(s);
            }

            var us = data as UserStories;
            if (us != null)
            {
                using (var db = GetRepository())
                {
                    db.Delete<UserStories>(new BsonValue(us.Id)) ;
                }
            }
        }
    }



}
