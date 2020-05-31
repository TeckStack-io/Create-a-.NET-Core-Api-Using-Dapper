using Microsoft.Azure.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace DapperCore.Services
{
    public interface IMessageBusService
    {
        Task CloseQueueAsync();
        Task ProcessMessagesAsync(Message message, CancellationToken token);
        void RegisterOnMessageHandlerAndReceiveMessages();
    }
}