using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjectionWithLazy.Models
{
    public class UserRepository : IUserRepository
    {
        protected DataContext Db { get; set; }

        public UserRepository(DataContext db)
        {
            Db = db;    
        }

        public void Add(User user)
        {
            Db.Users.Add(user);
            Db.SaveChanges();
        }
    }

    public interface IUserRepository
    {
        void Add(User user);
    }
}