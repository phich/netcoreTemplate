using AutoMapper;
using CreateTemplate.Api.Configuration;
using CreateTemplate.Api.Filters;
using CreateTemplate.Api.ModelBinders;
using CreateTemplate.Business.Identity;
using CreateTemplate.Business.Services;
using CreateTemplate.Business.Services.Interfaces;
using CreateTemplate.Core.AppSettings;
using CreateTemplate.Core.Configuration;
using CreateTemplate.Core.Identity;

using CreateTemplate.Data.Contexts;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CreateTemplate.Api
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

      public void ConfigureServices(IServiceCollection services)
      {
        services.AddDbContext(Configuration.GetConnectionString("DbConnectionString"));
        services.AddAutoMapper();
        services.AddSwagger();
        services.AddJwtIdentity(Configuration.GetSection(nameof(JwtConfiguration)));

        services.AddLogging(logBuilder => logBuilder.AddSerilog(dispose: true));

        services.AddTransient<IUsersService, UsersService>();
        services.AddTransient<IJwtFactory, JwtFactory>();
        services.AddSingleton<IEmailSetting>(Configuration.GetSection("EmailConfiguration").Get<EmailSettings>());
      

    services.AddMvc(options =>
          {
            options.ModelBinderProviders.Insert(0, new OptionModelBinderProvider());
            options.Filters.Add<ExceptionFilter>();
            options.Filters.Add<ModelStateFilter>();
          })
          .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ApplicationDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                dbContext.Database.EnsureCreated();
            }
            else
            {
                app.UseHsts();
            }

            loggerFactory.AddLogging(Configuration.GetSection("Logging"));

            app.UseHttpsRedirection();
            app.UseSwagger("My Web API.");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
