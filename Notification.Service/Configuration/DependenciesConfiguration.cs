using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Notification.Service.Consumer;

namespace Notification.Service.Configuration
{
    public static class DependenciesConfiguration
    {
        public static void AddNotificationService(this IServiceCollection services)
        {
            services.AddMassTransit();
        }

        private static void AddMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<EventConsumer>();
                x.SetKebabCaseEndpointNameFormatter();
                x.UsingRabbitMq((context, cfg) =>
                {
                    //cfg.ReceiveEndpoint("event-listener", e =>
                    //{
                    //    e.ConfigureConsumer<EventConsumer>(context);
                    //});

                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddMassTransitHostedService();
        }
    }
}
