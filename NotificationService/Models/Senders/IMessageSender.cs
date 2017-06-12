using System.Threading.Tasks;
using Bootstrap.Service.NotificationService.Models.Messages;
using Bootstrap.Service.NotificationService.Models.ResponseModels;

namespace Bootstrap.Service.NotificationService.Models.Senders
{
    public interface IMessageSender<in TMessage> where TMessage : Message
    {
        Task<BaseResponse> Send(TMessage message);
    }
}