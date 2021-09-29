using Notification.Contracts.Settings.MongoDb;
using Notification.Data.DBContext;
using Notification.Data.Entities;

namespace Notification.Data.Repositories
{
    class BookRepository : MingoProvider<Book>
    {
        public BookRepository(IDatabaseSettings settings)
               : base(settings)
        { }
    }
}
