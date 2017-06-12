using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Service.NotificationService.Models.Messages;
using Microsoft.EntityFrameworkCore;

namespace Bootstrap.Service.NotificationService.Models
{
    public abstract class NotificationDbContext : DbContext
    {
        public DbSet<EmailMessage> EmailMessages { get; set; }
        public DbSet<SmsMessage> SmsMessages { get; set; }
        public DbSet<WeChatTemplateMessage> WeChatTemplateMessages { get; set; }
    }
}