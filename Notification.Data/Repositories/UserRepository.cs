using Microsoft.Extensions.Options;
using Notification.Contracts.Settings.MongoDb;
using Notification.Data.DBContext;
using Notification.Data.Entities;
using Notification.Data.Repositories.Interface;

namespace Notification.Data.Repositories
{
    public class UserRepository : MongoProvider<User>, IUserRepository
    {
        public UserRepository(IOptions<DatabaseSettings> settings)
            : base(settings, nameof(User))
        { }
    }
}
