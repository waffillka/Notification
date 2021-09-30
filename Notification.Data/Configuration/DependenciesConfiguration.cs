using Microsoft.Extensions.DependencyInjection;
using Notification.Data.DBContext;

namespace Notification.Data.Configuration
{
    public static class DependenciesConfiguration
    {
        public static void AddNotificationData(this IServiceCollection services)
        {
            services.AddMongoDb();
        }

        private static void AddMongoDb(this IServiceCollection services)
        {
            var currentAssembly = typeof(DependenciesConfiguration);

            services.Scan(scan => scan.FromAssembliesOf(currentAssembly)
                                      .AddClasses(classes => classes.AssignableTo(typeof(IMongoProvider<>)))
                                      .AsImplementedInterfaces()
                                      .WithTransientLifetime()
                         );
        }
    }
}
