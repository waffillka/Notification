using MediatR;
using Notification.Application.Handler;
using Notification.Application.Logger;
using Notification.Contracts.DataTransferObject.Broker;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Commands.Broker
{
    public class SubscriptionCommand : IRequest
    {
        public SubscriptionCommand(Subscription subscription)
        {
            Subscription = subscription;
        }

        public Subscription Subscription { get; set; }
    }

    public class SubscriptionCommandHandler : LoggerRequestHandler<SubscriptionCommand, Unit>
    {
        public SubscriptionCommandHandler(ILoggerManager logger)
            : base(logger)
        { }

        public async override Task<Unit> HandleInternalAsync(SubscriptionCommand request, CancellationToken cancellationToken)
        {
            //...
            return Unit.Value;
        }
    }
}
