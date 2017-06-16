using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using testdotnet2.Infrastructure;
using Infrastructure.Services;
using Infrastructure.Repositories;
using Core.Repositiories;
using Infrastructure.Mappers;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.IoC.Modules;
using Infrastructure.IoC;

namespace testdotnet2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            string domain = "https://mik.eu.auth0.com/";


            services.AddAuthorization(a => a.AddPolicy("read:userinfo", b => b.RequireRole("read:userinfo")));
            services.AddMvc();


            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:userinfo",
                    policy => policy.Requirements.Add(new HasScopeRequirement("read:userinfo", domain)));

            });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ContainerModule(Configuration));
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var options = new JwtBearerOptions
            {
                //Audience = Configuration["Auth0:ApiIdentifier"],
                //Authority = $"https://{Configuration["Auth0:Domain"]}/"
                Audience = "http://localhost:1496/",
                Authority = "https://mik.eu.auth0.com"
            };
            app.UseJwtBearerAuthentication(options);

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
