using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Notification.Contracts.Settings.MongoDb;
using Notification.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Data.DBContext
{
    public abstract class MongoProvider<TEntity> : IMongoProvider<TEntity>
        where TEntity : IIdentifiable<Guid>, ISoftDeleteable
    {
        protected IMongoCollection<TEntity> _provider;

        public MongoProvider(IOptions<DatabaseSettings> settings, string nameTable)
        {
            var connection = new MongoUrlBuilder(settings.Value.ConnectionString);
            MongoClient client = new MongoClient(settings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.Value.DatabaseName);
            _provider = database.GetCollection<TEntity>(nameTable);
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct = default)
        {
            _provider.InsertOneAsync(entity, ct);
            return entity;
        }

        public async Task<ICollection<TEntity>> ReadAsync() =>
            _provider.Find(sub => true).ToList();

        public async Task<TEntity> Find(Guid id, CancellationToken ct = default) =>
            _provider.Find(sub => sub.Id == id).SingleOrDefault(ct);

        public async Task<ICollection<TEntity>> Find(ICollection<Guid> ids, CancellationToken ct = default) =>
            _provider.Find(x => ids.Contains(x.Id)).ToList(ct);

        public Task UpdateAsync(TEntity entity) =>
            _provider.ReplaceOneAsync(sub => sub.Id == entity.Id, entity);

        public Task Delete(Guid id, CancellationToken ct = default) =>
            _provider.DeleteOneAsync(sub => sub.Id == id, ct);

        public async Task<ICollection<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default)
        {
            return _provider.Find(expression).ToList(ct);
        }

        public async Task<TEntity> GetOneByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default)
        {
            return _provider.Find(expression).SingleOrDefault(ct);
        }
    }
}
