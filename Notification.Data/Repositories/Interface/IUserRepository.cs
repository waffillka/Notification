using Notification.Data.DBContext;
using Notification.Data.Entities;

namespace Notification.Data.Repositories.Interface
{
    public interface IUserRepository : IMongoProvider<User>
    {
    }
}
