﻿using MassTransit;
using Notification.Application.Logger;
using System.Threading.Tasks;

namespace Notification.Application.Consumer
{
    public abstract class BaseConsumer<TMessage> : IConsumer<TMessage>
        where TMessage : class
    {
        protected ILoggerManager _logger;

        public BaseConsumer(ILoggerManager logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TMessage> context)
        {
            _logger.LogInfo($"{typeof(TMessage)} message {context.Message}");

            return ConsumeInternalAsync(context);
        }

        public abstract Task ConsumeInternalAsync(ConsumeContext<TMessage> context);
    }
}
