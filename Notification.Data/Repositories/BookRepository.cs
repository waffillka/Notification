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
    public class BookRepository : MongoProvider<Book>, IBookRepository
    {
        public BookRepository(IOptions<DatabaseSettings> settings)
            : base(settings, nameof(Book))
        { }

        public async Task<Book> GetOneByBookId(Guid id, CancellationToken ct = default)
        {
            var entity = _provider.Find(x => x.Id == id).FirstOrDefaultAsync(ct);
            return entity.Result;
        }
    }
}
