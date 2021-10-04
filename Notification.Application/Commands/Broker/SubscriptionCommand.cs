using MediatR;
using Notification.Application.Handler;
using Notification.Application.Logger;
using Notification.Contracts.DataTransferObject.Broker;
using Notification.Data.Entities;
using Notification.Data.Repositories.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Commands.Broker
{
    public class SubscriptionCommand : IRequest
    {
        public SubscriptionCommand(Subscription subscription)
        {
            Subscription = subscription;
        }

        public Subscription Subscription { get; set; }
    }

    public class SubscriptionCommandHandler : LoggerRequestHandler<SubscriptionCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public SubscriptionCommandHandler(ILoggerManager logger, IBookRepository bookRepository, IUserRepository userRepository)
            : base(logger)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async override Task<Unit> HandleInternalAsync(SubscriptionCommand request, CancellationToken ct)
        {
            var entityUser = await _userRepository.GetOneByCondition(x => x.Id == request.Subscription.UserId, ct);
            var entityBook = await _bookRepository.GetOneByCondition(x => x.Id == request.Subscription.BookId, ct);

            if (entityUser is null)
            {
                entityUser = new User()
                {
                    Name = request.Subscription.UserName,
                    Nickname = request.Subscription.UserName,
                    Email = request.Subscription.UserEmail,
                    Id = request.Subscription.UserId,
                    SubscriptionDate = request.Subscription.SubscriptionDate
                };

                await _userRepository.CreateAsync(entityUser, ct);
            }

            if (entityBook is null)
            {
                entityBook = new Book()
                {
                    Id = request.Subscription.BookId,
                    Name = request.Subscription.BookName,
                    ISBN = request.Subscription.BookISBIN,
                    Authors = request.Subscription.Authors
                };

                await _bookRepository.CreateAsync(entityBook, ct);
            }

            entityBook.Users.Add(entityUser.Id);
            entityUser.Books.Add(entityBook.Id);

            await _bookRepository.UpdateAsync(entityBook);
            await _userRepository.UpdateAsync(entityUser);

            return Unit.Value;
        }
    }
}
