using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Service.NotificationService.Models.Messages;

namespace Bootstrap.Service.NotificationService.Models.Senders
{
    public interface ISmsSender : IMessageSender<SmsMessage>
    {
    }
}
