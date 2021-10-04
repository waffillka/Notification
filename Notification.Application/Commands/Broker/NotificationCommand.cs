using MediatR;
using Notification.Application.Handler;
using Notification.Application.Logger;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Commands.Broker
{
    public class NotificationCommand : IRequest
    {
        public NotificationCommand(Contracts.DataTransferObject.Broker.Notification freeBook)
        {
            FreeBook = freeBook;
        }

        public Contracts.DataTransferObject.Broker.Notification FreeBook { get; set; }
    }

    public class NotificationHandler : LoggerRequestHandler<NotificationCommand, Unit>
    {
        public NotificationHandler(ILoggerManager logger)
            : base(logger)
        { }

        public async override Task<Unit> HandleInternalAsync(NotificationCommand request, CancellationToken cancellationToken)
        {
            //...
            return Unit.Value;
        }
    }

}
