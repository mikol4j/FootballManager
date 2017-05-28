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

namespace testdotnet2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            string domain = "https://mik.eu.auth0.com/";


            services.AddAuthorization(a => a.AddPolicy("read:userinfo", b => b.RequireRole("read:userinfo")));
            services.AddMvc();
            services.AddScoped<IUserRepository, UserRepository>(); // Scoped per request
            services.AddScoped<IUserService, UserService>(); // Scoped per request

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:userinfo",
                    policy => policy.Requirements.Add(new HasScopeRequirement("read:userinfo", domain)));

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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
        }
    }
}
