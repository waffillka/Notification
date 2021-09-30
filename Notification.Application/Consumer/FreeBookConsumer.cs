using MassTransit;
using MediatR;
using Notification.Application.Commands.Broker;
using Notification.Application.Logger;
using Notification.Contracts.DataTransferObject.Broker;
using System.Threading.Tasks;

namespace Notification.Application.Consumer
{
    public class FreeBookConsumer : LoggerConsumer<FreeBook>
    {
        private readonly IMediator _mediator;

        public FreeBookConsumer(IMediator mediator, ILoggerManager logger)
            : base(logger)
        {
            _mediator = mediator;
        }

        public async override Task ConsumeInternalAsync(ConsumeContext<FreeBook> context)
        {
            _mediator.Send(new FreeBookCommand(context.Message));
        }
    }

}
