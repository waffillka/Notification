using MediatR;
using Notification.Application.Handler;
using Notification.Application.Logger;
using Notification.Contracts.DataTransferObject.Broker;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Commands.Broker
{
    public class FreeBookCommand : IRequest
    {
        public FreeBookCommand(FreeBook freeBook)
        {
            FreeBook = freeBook;
        }

        public FreeBook FreeBook { get; set; }
    }

    public class FreeBookCommandHandler : LoggerRequestHandler<FreeBookCommand, Unit>
    {
        public FreeBookCommandHandler(ILoggerManager logger)
            : base(logger)
        { }

        public async override Task<Unit> HandleInternalAsync(FreeBookCommand request, CancellationToken cancellationToken)
        {
            //...
            return Unit.Value;
        }
    }

}
