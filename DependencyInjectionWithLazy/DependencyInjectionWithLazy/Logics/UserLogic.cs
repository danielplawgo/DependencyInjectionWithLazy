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
        protected IUserRepository UserRepository { get; set; }

        protected UserValidator Validator { get; set; }

        public UserLogic(IUserRepository userRepository,
            UserValidator validator)
        {
            UserRepository = userRepository;
            Validator = validator;
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