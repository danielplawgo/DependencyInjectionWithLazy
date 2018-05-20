using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Core;
using DependencyInjectionWithLazy.Infrastructure;

namespace DependencyInjectionWithLazy.App_Start.AutofacModules
{
    public class LoggerModule : Module
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new LoggerInterceptor());
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry,
            IComponentRegistration registration)
        {
            registration.Activating += OnActivating;
            base.AttachToComponentRegistration(componentRegistry, registration);
        }

        private void OnActivating(object sender, ActivatingEventArgs<object> e)
        {
            _logger.Info($"Activating: {e.Component.Activator.LimitType}");
        }
    }
}