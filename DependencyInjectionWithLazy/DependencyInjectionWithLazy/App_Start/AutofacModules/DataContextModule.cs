using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using DependencyInjectionWithLazy.Models;

namespace DependencyInjectionWithLazy.App_Start.AutofacModules
{
    public class DataContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataContext>()
                .InstancePerRequest();

        }
    }
}