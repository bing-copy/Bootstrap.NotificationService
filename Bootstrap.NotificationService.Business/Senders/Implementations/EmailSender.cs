﻿using System.Threading.Tasks;
using Bootstrap.Components.Models.ResponseModels;
using Bootstrap.Service.NotificationService.Models.Messages;

namespace Bootstrap.Service.NotificationService.Business.Senders.Implementations
{
    public class EmailSender : IEmailSender
    {
        public async Task<BaseResponse> Send(EmailMessage message)
        {
            return await Task.FromResult(new BaseResponse());
        }
    }
}
