using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjectionWithLazy.Models
{
    public class UserRepository : IUserRepository
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        private Lazy<DataContext> _db;
        protected DataContext Db
        {
            get { return _db.Value; }
        }

        public UserRepository(Lazy<DataContext> db)
        {
            _db = db;
            
            _logger.Info("UserRepository.ctor");    
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