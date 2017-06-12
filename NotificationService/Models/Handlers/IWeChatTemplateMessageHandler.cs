using System.Threading.Tasks;
using Bootstrap.Service.NotificationService.Models.Messages;
using Bootstrap.Service.NotificationService.Models.RequestModels;
using Bootstrap.Service.NotificationService.Models.ResponseModels;

namespace Bootstrap.Service.NotificationService.Models.Handlers
{
    public interface IWeChatTemplateMessageHandler : IMessageHandler<WeChatTemplateMessage>
    {
        Task<SearchResponse<WeChatTemplateMessage>> Search(WeChatTemplateMessageSearchRequestModel model);
    }
}
