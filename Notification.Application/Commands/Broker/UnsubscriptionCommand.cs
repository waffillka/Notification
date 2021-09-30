using MediatR;
using Notification.Application.Handler;
using Notification.Application.Logger;
using Notification.Contracts.DataTransferObject.Broker;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Commands.Broker
{
    public class UnsubscriptionCommand : IRequest
    {
        public UnsubscriptionCommand(Unsubscription unsubscription)
        {
            Unsubscription = unsubscription;
        }

        public Unsubscription Unsubscription { get; set; }
    }

    public class UnsubscriptionCommandHandler : LoggerRequestHandler<UnsubscriptionCommand, Unit>
    {
        public UnsubscriptionCommandHandler(ILoggerManager logger)
            : base(logger)
        { }

        public async override Task<Unit> HandleInternalAsync(UnsubscriptionCommand request, CancellationToken cancellationToken)
        {
            //...
            return Unit.Value;
        }
    }

}
