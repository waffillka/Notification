using Bookcrossing.Contracts.DataTransferObjects.Broker;
using MassTransit;
using System.Threading.Tasks;

namespace Notification.Service.Consumer
{
    class EventConsumer : IConsumer<BrokerMessage>
    {
        //ILogger<EventConsumer> _logger;

        public EventConsumer(/*ILogger<EventConsumer> logger*/)
        {
            //_logger = logger;
        }

        public async Task Consume(ConsumeContext<BrokerMessage> context)
        {
            int i = 0;
            i++;
        }
    }
}
