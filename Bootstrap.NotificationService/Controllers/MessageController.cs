using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Service.NotificationService.Models.Messages;
using Bootstrap.Components.Models.ResponseModels;
using Bootstrap.Service.NotificationService.Business.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Bootstrap.Service.NotificationService.Controllers
{
    [Route("[controller]")]
    public abstract class MessageController<TMessage> : Controller where TMessage : Message
    {
        protected readonly IMessageHandler<TMessage> MessageHandler;

        protected MessageController(IMessageHandler<TMessage> messageHandler)
        {
            MessageHandler = messageHandler;
        }
        [HttpPost]
        public virtual async Task<BaseResponse> Send(TMessage message)
        {
            var result = await MessageHandler.Save(message);
            if (result.Code == 0)
            {
                result = await MessageHandler.Send(message);
                return result;
            }
            return result;
        }
    }
}