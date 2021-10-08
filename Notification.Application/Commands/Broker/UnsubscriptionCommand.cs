using MediatR;
using Notification.Application.Handler;
using Notification.Application.Logger;
using Notification.Contracts.DataTransferObject.Broker;
using Notification.Data.Repositories.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Commands.Broker
{
    public class UnsubscriptionCommand : IRequest
    {
        public UnsubscriptionCommand(Unsubscription unsubscription)
        {
            Unsubscription = unsubscription;
        }

        public Unsubscription Unsubscription { get; set; }
    }

    public class UnsubscriptionCommandHandler : RequestHandlerBase<UnsubscriptionCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public UnsubscriptionCommandHandler(ILoggerManager logger, IBookRepository bookRepository, IUserRepository userRepository)
            : base(logger)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async override Task<Unit> HandleInternalAsync(UnsubscriptionCommand request, CancellationToken ct)
        {
            var entityBook = await _bookRepository.GetOneByCondition(x => x.Id == request.Unsubscription.BookId);
            var entitiesUser = await _userRepository.GetOneByCondition(x => x.Id == request.Unsubscription.UserId);

            entitiesUser.Books.Remove(entityBook.Id);
            _userRepository.UpdateAsync(entitiesUser);

            entityBook.Users.Remove(entitiesUser.Id);
            _bookRepository.UpdateAsync(entityBook);

            return Unit.Value;
        }
    }

}
