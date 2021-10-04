using MassTransit;
using MediatR;
using Notification.Application.Commands.Broker;
using Notification.Application.Logger;
using Notification.Contracts.DataTransferObject.Broker;
using System.Threading.Tasks;

namespace Notification.Application.Consumer
{
    public class UnsubscriptionConsumer : LoggerConsumer<Unsubscription>
    {
        private readonly IMediator _mediator;

        public UnsubscriptionConsumer(IMediator mediator, ILoggerManager logger)
            : base(logger)
        {
            _mediator = mediator;
        }

        public async override Task ConsumeInternalAsync(ConsumeContext<Unsubscription> context)
        {
            await _mediator.Send(new UnsubscriptionCommand(context.Message));
        }
    }
}
