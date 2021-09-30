using Notification.Contracts.Settings.MongoDb;
using Notification.Data.DBContext;
using Notification.Data.Entities;
using Notification.Data.Repositories.Interface;

namespace Notification.Data.Repositories
{
    public class UserRepository : MongoProvider<User>, IUserRepository
    {
        public UserRepository(IDatabaseSettings settings)
            : base(settings, nameof(User))
        { }
    }
}
