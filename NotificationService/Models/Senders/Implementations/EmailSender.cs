using System.Threading.Tasks;
using Bootstrap.Service.NotificationService.Models.Messages;
using Bootstrap.Service.NotificationService.Models.ResponseModels;

namespace Bootstrap.Service.NotificationService.Models.Senders.Implementations
{
    public class EmailSender : IEmailSender
    {
        public async Task<BaseResponse> Send(EmailMessage message)
        {
            return await Task.FromResult(new BaseResponse());
        }
    }
}
