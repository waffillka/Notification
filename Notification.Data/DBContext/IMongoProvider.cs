using Notification.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification.Data.DBContext
{
    public interface IMongoProvider<TEntity>
        where TEntity : IIdentifiable<Guid>, ISoftDeleteable
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<ICollection<TEntity>> ReadAsync();
        Task<TEntity> Find(Guid id);
        Task UpdateAsync(TEntity entity);
        Task Delete(Guid id);
    }
}
