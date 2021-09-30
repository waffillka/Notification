using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Notification.Application.Consumer;
using Notification.Application.Logger;
using Notification.Application.Mapping;
using System.Reflection;

namespace Notification.Service.Configuration
{
    public static class DependenciesConfiguration
    {
        public static void AddNotificationService(this IServiceCollection services)
        {
            services.AddMassTransit();
            services.RegisterMapping();
            services.RegisterMediator();
            services.RegisterLogger();
        }

        private static void AddMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<FreeBookConsumer>();
                x.AddConsumer<SubscriptionConsumer>();
                x.AddConsumer<UnsubscriptionConsumer>();
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

        private static void RegisterMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(
                c => c.AddProfile<MappingConfiguration>(),
                typeof(MappingConfiguration));
        }

        private static void RegisterMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        private static void RegisterLogger(this IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
        }
    }
}
