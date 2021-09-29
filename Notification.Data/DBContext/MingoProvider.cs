using MongoDB.Driver;
using Notification.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Data.DBContext
{
    public class MingoProvider<TEntity>
        where TEntity : IIdentifiable<Guid>, ISoftDeleteable
    {
        protected IMongoCollection<TEntity> _provider;

        public MingoProvider(string connectionString)
        {
            var connection = new MongoUrlBuilder(connectionString);
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            // получаем доступ к самой базе данных
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            // обращаемся к коллекции Products
            _provider = database.GetCollection<TEntity>(nameof(TEntity));
        }
    }
}
