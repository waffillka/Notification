using MassTransit;
using MediatR;
using Notification.Application.Commands.Broker;
using Notification.Application.Logger;
using Notification.Contracts.DataTransferObject.Broker;
using System.Threading.Tasks;

namespace Notification.Application.Consumer
{
    public class SubscriptionListener : BaseConsumer<Subscription>
    {
        private readonly IMediator _mediator;

        public SubscriptionListener(IMediator mediator, ILoggerManager logger)
            : base(logger)
        {
            _mediator = mediator;
        }

        public async override Task ConsumeInternalAsync(ConsumeContext<Subscription> context)
        {
            await _mediator.Send(new HandleSubscriptionCommand(context.Message));
        }
    }
}
