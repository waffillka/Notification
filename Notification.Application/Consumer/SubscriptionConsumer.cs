using MassTransit;
using MediatR;
using Notification.Application.Commands.Broker;
using Notification.Application.Logger;
using Notification.Contracts.DataTransferObject.Broker;
using System.Threading.Tasks;

namespace Notification.Application.Consumer
{
    public class SubscriptionConsumer : LoggerConsumer<Subscription>
    {
        private readonly IMediator _mediator;

        public SubscriptionConsumer(IMediator mediator, ILoggerManager logger)
            : base(logger)
        {
            _mediator = mediator;
        }

        public async override Task ConsumeInternalAsync(ConsumeContext<Subscription> context)
        {
            await _mediator.Send(new SubscriptionCommand(context.Message));
        }
    }
}
