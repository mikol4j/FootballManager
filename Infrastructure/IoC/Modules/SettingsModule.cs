using Autofac;
using Microsoft.Extensions.Configuration;
using Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Extensions;

namespace Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>()).SingleInstance();
        }
    }
}
