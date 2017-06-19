using System.Threading.Tasks;

namespace Bootstrap.Service.NotificationService.Models.Senders.Implementations.WeChatMessageSender
{
    public interface IWeChatAccessTokenProvider
    {
        Task<string> GetAccessToken();
    }
}
