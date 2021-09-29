using Notification.Contracts.Settings.MongoDb;
using Notification.Data.DBContext;
using Notification.Data.Entities;

namespace Notification.Data.Repositories
{
    public class UserRepository : MingoProvider<Book>
    {
        public UserRepository(IDatabaseSettings settings)
            : base(settings)
        { }
    }
}
