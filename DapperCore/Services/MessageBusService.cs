using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace DapperCore.Services
{
    public class MessageBusService : IMessageBusService
    {
        private readonly QueueClient queueClient;

        public MessageBusService(IConfiguration configuration)
        {
            queueClient = new QueueClient(configuration["ServiceBusConnectionString"], "testqueue");
        }

        public void RegisterOnMessageHandlerAndReceiveMessages()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        public async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            // process message here
            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            return Task.CompletedTask;
        }

        public async Task CloseQueueAsync()
        {
            await queueClient.CloseAsync();
        }
    }
}
