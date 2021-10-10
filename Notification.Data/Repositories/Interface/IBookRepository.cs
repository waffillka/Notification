using Notification.Data.DBContext;
using Notification.Data.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Data.Repositories.Interface
{
    public interface IBookRepository : IMongoProvider<Book>
    {
        Task<Book> GetOneByBookId(Guid id, CancellationToken ct = default);
    }
}
