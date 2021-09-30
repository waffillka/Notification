using MassTransit;
using Notification.Application.Logger;
using System.Threading.Tasks;

namespace Notification.Application.Consumer
{
    public abstract class LoggerConsumer<TMessage> : IConsumer<TMessage>
        where TMessage : class
    {
        protected ILoggerManager _logger;

        public LoggerConsumer(ILoggerManager logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TMessage> context)
        {
            _logger.LogInfo($"{typeof(TMessage)}");

            return ConsumeInternalAsync(context);
        }

        public abstract Task ConsumeInternalAsync(ConsumeContext<TMessage> context);
    }
}
