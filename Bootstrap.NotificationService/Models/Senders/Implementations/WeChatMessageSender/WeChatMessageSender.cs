using System.Threading.Tasks;
using Bootstrap.Service.NotificationService.Models.Messages;
using Bootstrap.Service.NotificationService.Models.ResponseModels;

namespace Bootstrap.Service.NotificationService.Models.Senders.Implementations.WeChatMessageSender
{
    public class WeChatMessageSender : IWeChatTemplateMessageSender
    {
        public async Task<BaseResponse> Send(WeChatTemplateMessage message)
        {
            return await Task.FromResult(new BaseResponse());
        }
    }
}
