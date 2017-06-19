using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Service.NotificationService.Models.Handlers;
using Bootstrap.Service.NotificationService.Models.Messages;
using Bootstrap.Service.NotificationService.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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