using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DependencyInjectionWithLazy.Models;
using FluentValidation;

namespace DependencyInjectionWithLazy.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty();

            RuleFor(u => u.LastName)
                .NotEmpty();
        }
    }
}