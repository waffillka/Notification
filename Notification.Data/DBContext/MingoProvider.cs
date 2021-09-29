using MongoDB.Driver;
using Notification.Contracts.Settings.MongoDb;
using Notification.Data.Interfaces;
using System;
using System.Collections.Generic;

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

        public TEntity Create(TEntity entity)
        {
            _provider.InsertOne(entity);
            return entity;
        }

        public IList<TEntity> Read() =>
            _provider.Find(sub => true).ToList();

        public TEntity Find(Guid id) =>
            _provider.Find(sub => sub.Id == id).SingleOrDefault();

        public void Update(TEntity entity) =>
            _provider.ReplaceOne(sub => sub.Id == entity.Id, entity);

        public void Delete(Guid id) =>
            _provider.DeleteOne(sub => sub.Id == id);
    }
}
