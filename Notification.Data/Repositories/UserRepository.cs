using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Notification.Contracts.Settings.MongoDb;
using Notification.Data.DBContext;
using Notification.Data.Entities;
using Notification.Data.Repositories.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Data.Repositories
{
    public class UserRepository : MongoProvider<User>, IUserRepository
    {
        public UserRepository(IOptions<DatabaseSettings> settings)
            : base(settings, nameof(User))
        { }

        public async Task<User> GetOneByUserId(Guid id, CancellationToken ct = default)
        {
            var entity = _provider.Find(x => x.Id == id).FirstOrDefaultAsync(ct);
            return entity.Result;
        }
    }
}
