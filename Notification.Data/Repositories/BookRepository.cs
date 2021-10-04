using Microsoft.Extensions.Options;
using Notification.Contracts.Settings.MongoDb;
using Notification.Data.DBContext;
using Notification.Data.Entities;
using Notification.Data.Repositories.Interface;

namespace Notification.Data.Repositories
{
    public class BookRepository : MongoProvider<Book>, IBookRepository
    {
        public BookRepository(IOptions<DatabaseSettings> settings)
            : base(settings, nameof(Book))
        { }
    }
}
