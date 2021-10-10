using Notification.Data.DBContext;
using Notification.Data.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Data.Repositories.Interface
{
    public interface IUserRepository : IMongoProvider<User>
    {
        Task<User> GetOneByUserId(Guid id, CancellationToken ct = default);
    }
}
