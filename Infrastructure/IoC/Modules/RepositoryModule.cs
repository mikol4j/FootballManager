using Autofac;
using Core.Repositiories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructure.IoC.Modules
{
    class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();


        }
    }
}