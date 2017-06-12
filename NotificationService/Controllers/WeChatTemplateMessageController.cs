using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Service.NotificationService.Models;
using Bootstrap.Service.NotificationService.Models.Handlers;
using Bootstrap.Service.NotificationService.Models.Messages;
using Bootstrap.Service.NotificationService.Models.RequestModels;
using Bootstrap.Service.NotificationService.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Bootstrap.Service.NotificationService.Controllers
{
    public class WeChatTemplateMessageController : MessageController<WeChatTemplateMessage>
    {
        private readonly IWeChatTemplateMessageHandler _messageHandler;

        public WeChatTemplateMessageController(IWeChatTemplateMessageHandler messageHandler) : base(messageHandler)
        {
            _messageHandler = messageHandler;
        }

        [HttpGet("[action]")]
        public virtual async Task<SearchResponse<WeChatTemplateMessage>> Search(WeChatTemplateMessageSearchRequestModel model)
        {
            return await _messageHandler.Search(model);
        }
    }
}