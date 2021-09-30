using MassTransit;
using MassTransit.Courier.Contracts;
using Notification.Application.Logger;
using System.Threading.Tasks;

namespace Notification.Application.Consumer
{
    public class SubscriptionConsumer : LoggerConsumer<Subscription>
    {
        public SubscriptionConsumer(ILoggerManager logger)
            : base(logger)
        {
        }

        public async override Task ConsumeInternalAsync(ConsumeContext<Subscription> context)
        {
            int i = 0;
            i++;
        }
    }
}
