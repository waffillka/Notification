using MediatR;
using Notification.Application.Handler;
using Notification.Application.Logger;
using Notification.Contracts.Settings.Mail;
using Notification.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Commands.Mail
{
    public class MailCommand : IRequest
    {
        public MailCommand(User user, Book book)
        {
            Book = book;
            User = user;
        }

        public User User { get; set; }
        public Book Book { get; set; }
        
    }

    public class MailCommandHandler : LoggerRequestHandler<MailCommand, Unit>
    {
        public MailCommandHandler(ILoggerManager logger, IEmailSettings emailSettings)
            : base(logger)
        {
            EmailSettings = emailSettings;
        }

        public IEmailSettings EmailSettings { get; set; }

        public async override Task<Unit> HandleInternalAsync(MailCommand request, CancellationToken cancellationToken)
        {
            
            return Unit.Value;
        }
    }
}
