using Notification.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Data.DBContext
{
    public interface IMongoProvider<TEntity>
        where TEntity : IIdentifiable<Guid>, ISoftDeleteable
    {
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct = default);
        Task<ICollection<TEntity>> ReadAsync();
        Task<TEntity> Find(Guid id, CancellationToken ct = default);
        Task Delete(Guid id, CancellationToken ct = default);
        Task<ICollection<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default);
        Task<TEntity> GetOneByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default);
        Task UpdateAsync(TEntity entity);
    }
}
