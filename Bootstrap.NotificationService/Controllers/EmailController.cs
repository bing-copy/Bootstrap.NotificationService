using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Service.NotificationService.Models;
using Bootstrap.Service.NotificationService.Models.Messages;
using Bootstrap.Service.NotificationService.Models.RequestModels;
using Bootstrap.Components.Models.ResponseModels;
using Bootstrap.Service.NotificationService.Business.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Bootstrap.Service.NotificationService.Controllers
{
    public class EmailController : MessageController<EmailMessage>
    {
        private readonly IEmailHandler _messageHandler;

        public EmailController(IEmailHandler messageHandler) : base(messageHandler)
        {
            _messageHandler = messageHandler;
        }
        [HttpGet("[action]")]
        public virtual async Task<SearchResponse<EmailMessage>> Search(EmailMessageSearchRequestModel model)
        {
            return await _messageHandler.Search(model);
        }
    }
}