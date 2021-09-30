using MassTransit;
using Notification.Application.Logger;
using Notification.Contracts.DataTransferObject.Broker;
using System.Threading.Tasks;

namespace Notification.Application.Consumer
{
    public class UnsubscriptionConsumer : LoggerConsumer<Unsubscription>
    {
        public UnsubscriptionConsumer(ILoggerManager logger)
            : base(logger)
        {
        }

        public async override Task ConsumeInternalAsync(ConsumeContext<Unsubscription> context)
        {
            int i = 0;
            i++;
        }
    }
}
