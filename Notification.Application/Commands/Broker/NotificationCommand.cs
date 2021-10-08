using MediatR;
using Notification.Application.Commands.Mail;
using Notification.Application.Handler;
using Notification.Application.Logger;
using Notification.Data.Repositories.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Commands.Broker
{
    public class NotificationCommand : IRequest
    {
        public NotificationCommand(Contracts.DataTransferObject.Broker.Notification freeBook)
        {
            FreeBook = freeBook;
        }

        public Contracts.DataTransferObject.Broker.Notification FreeBook { get; set; }
    }

    public class NotificationHandler : RequestHandlerBase<NotificationCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public NotificationHandler(ILoggerManager logger, IBookRepository bookRepository, IUserRepository userRepository, IMediator mediator)
            : base(logger)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async override Task<Unit> HandleInternalAsync(NotificationCommand request, CancellationToken ct)
        {
            var entityBook = await _bookRepository.GetOneByCondition(x => x.Id == request.FreeBook.BookId);
            var entitiesUser = await _userRepository.Find(entityBook.Users, ct);

            foreach (var item in entitiesUser)
            {
                _mediator.Send(new MailCommand(item, entityBook));
            }

            return Unit.Value;
        }
    }

}
