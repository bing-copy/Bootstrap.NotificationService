using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Service.NotificationService.Models;
using Bootstrap.Service.NotificationService.Models.Handlers;
using Bootstrap.Service.NotificationService.Models.Handlers.Implementations;
using Bootstrap.Service.NotificationService.Models.Senders;
using Bootstrap.Service.NotificationService.Models.Senders.Implementations;
using Bootstrap.Service.NotificationService.Models.Senders.Implementations.WeChatMessageSender;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddMvc();

            services.AddDbContext<NotificationDbContext>();

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

            app.UseMvcWithDefaultRoute();
        }
    }
}