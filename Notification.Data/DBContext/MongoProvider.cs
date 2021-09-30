using MongoDB.Driver;
using Notification.Contracts.Settings.MongoDb;
using Notification.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification.Data.DBContext
{
    public abstract class MongoProvider<TEntity> : IMongoProvider<TEntity>
        where TEntity : IIdentifiable<Guid>, ISoftDeleteable
    {
        protected IMongoCollection<TEntity> _provider;

        public MongoProvider(IDatabaseSettings settings, string nameTable)
        {
            var connection = new MongoUrlBuilder(settings.ConnectionString);
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);
            _provider = database.GetCollection<TEntity>(nameTable);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _provider.InsertOneAsync(entity);
            return entity;
        }

        public async Task<ICollection<TEntity>> ReadAsync() =>
            _provider.Find(sub => true).ToList();

        public async Task<TEntity> Find(Guid id) =>
            _provider.Find(sub => sub.Id == id).SingleOrDefault();

        public Task UpdateAsync(TEntity entity) =>
            _provider.ReplaceOneAsync(sub => sub.Id == entity.Id, entity);

        public Task Delete(Guid id) =>
            _provider.DeleteOneAsync(sub => sub.Id == id);
    }
}
