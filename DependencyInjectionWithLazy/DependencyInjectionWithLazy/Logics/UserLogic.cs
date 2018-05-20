using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DependencyInjectionWithLazy.Models;
using DependencyInjectionWithLazy.Validators;

namespace DependencyInjectionWithLazy.Logics
{
    public class UserLogic : IUserLogic
    {
        private Lazy<IUserRepository> _userRepository;
        protected IUserRepository UserRepository
        {
            get { return _userRepository.Value; }
        }

        private Lazy<UserValidator> _validator;
        protected UserValidator Validator
        {
            get { return _validator.Value; }
        }

        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public UserLogic(Lazy<IUserRepository> userRepository,
            Lazy<UserValidator> validator)
        {
            _userRepository = userRepository;
            _validator = validator;

            _logger.Info("UserLogic.ctor");
        }

        public Result<User> Add(User user)
        {
            var validationResult = Validator.Validate(user);

            if (validationResult.IsValid == false)
            {
                return Result.Failure<User>(validationResult.Errors);
            }

            UserRepository.Add(user);

            return Result.Ok(user);
        }
    }

    public interface IUserLogic
    {
        Result<User> Add(User user);
    }
}