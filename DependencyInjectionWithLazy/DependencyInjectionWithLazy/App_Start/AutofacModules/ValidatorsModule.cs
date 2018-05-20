using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using FluentValidation;

namespace DependencyInjectionWithLazy.App_Start.AutofacModules
{
    public class ValidatorsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ValidatorsModule).Assembly)
                .Where(t => t.GetInterfaces().Contains(typeof(IValidator)))
                .InstancePerRequest();
        }
    }
}