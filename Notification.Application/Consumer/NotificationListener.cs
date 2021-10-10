using MassTransit;
using MediatR;
using Notification.Application.Commands.Broker;
using Notification.Application.Logger;
using System.Threading.Tasks;

namespace Notification.Application.Consumer
{
    public class NotificationListener : BaseConsumer<Contracts.DataTransferObject.Broker.Notification>
    {
        private readonly IMediator _mediator;

        public NotificationListener(IMediator mediator, ILoggerManager logger)
            : base(logger)
        {
            _mediator = mediator;
        }

        public async override Task ConsumeInternalAsync(ConsumeContext<Contracts.DataTransferObject.Broker.Notification> context)
        {
            await _mediator.Send(new NotificationCommand(context.Message));
        }
    }

}
