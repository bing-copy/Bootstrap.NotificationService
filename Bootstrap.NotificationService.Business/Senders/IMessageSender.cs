using System.Threading.Tasks;
using Bootstrap.Components.Models.ResponseModels;
using Bootstrap.Service.NotificationService.Models.Messages;

namespace Bootstrap.Service.NotificationService.Business.Senders
{
    public interface IMessageSender<in TMessage> where TMessage : Message
    {
        Task<BaseResponse> Send(TMessage message);
    }
}