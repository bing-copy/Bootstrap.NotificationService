using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Components.Filters;
using Bootstrap.Components.Middlewares;
using Bootstrap.Service.NotificationService.Business;
using Bootstrap.Service.NotificationService.Business.Handlers;
using Bootstrap.Service.NotificationService.Business.Handlers.Implementations;
using Bootstrap.Service.NotificationService.Business.Senders;
using Bootstrap.Service.NotificationService.Business.Senders.Implementations;
using Bootstrap.Service.NotificationService.Business.Senders.Implementations.WeChatMessageSender;
using Bootstrap.Service.NotificationService.Models.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bootstrap.Service.NotificationService
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
            services.AddMvc(t => t.Filters.Add(typeof(SimpleInvalidDataFilter)));

            var options = Configuration.GetSection(nameof(NotificationServiceOptions))
                .Get<NotificationServiceOptions>();

            services.AddDbContext<NotificationDbContext>(t =>
            {
                Action<MySqlDbContextOptionsBuilder> action = null;
                if (!string.IsNullOrEmpty(options.MigrationsAssembly))
                {
                    action = b => b.MigrationsAssembly(options.MigrationsAssembly);
                }
                t.UseMySql(options.DbConnectionString, action);
            });

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IEmailHandler, EmailHandler>();
            services.AddScoped<ISmsSender, SmsSender>();
            services.AddScoped<ISmsHandler, SmsHandler>();
            services.AddScoped<IWeChatTemplateMessageSender, WeChatMessageSender>();
            services.AddScoped<IWeChatTemplateMessageHandler, WeChatTemplateMessageHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSimpleExceptionHandler();

            app.UseMvcWithDefaultRoute();
        }
    }
}