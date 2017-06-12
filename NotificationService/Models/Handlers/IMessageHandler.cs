using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Service.NotificationService.Models.Messages;
using Bootstrap.Service.NotificationService.Models.RequestModels;
using Bootstrap.Service.NotificationService.Models.ResponseModels;
using Bootstrap.Service.NotificationService.Models.Senders;

namespace Bootstrap.Service.NotificationService.Models.Handlers
{
    public interface IMessageHandler<in TMessage> where TMessage : Message
    {
        Task<BaseResponse> Send(TMessage message);
        Task<BaseResponse> Save(TMessage message);
    }
}