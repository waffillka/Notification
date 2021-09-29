using MongoDB.Driver;
using Notification.Contracts.Settings.MongoDb;
using Notification.Data.Interfaces;
using System;

namespace Notification.Data.DBContext
{
    public abstract class MingoProvider<TEntity>
        where TEntity : IIdentifiable<Guid>, ISoftDeleteable
    {
        protected IMongoCollection<TEntity> _provider;

        public MingoProvider(IDatabaseSettings settings)
        {
            var connection = new MongoUrlBuilder(settings.ConnectionString);
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(settings.ConnectionString);
            // получаем доступ к самой базе данных
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);
            // обращаемся к коллекции Products
            _provider = database.GetCollection<TEntity>(nameof(TEntity));
        }
    }
}
