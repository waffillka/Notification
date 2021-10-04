using MailKit.Net.Smtp;
using MediatR;
using MimeKit;
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
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(EmailSettings.Name, EmailSettings.Email));
            message.To.Add(new MailboxAddress(request.User.UserName, request.User.UserEmail));
            message.Subject = $"{request.Book.Name} is free!";
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"{request.Book.Name} is free!\n" +
                $"Dear {request.User.UserName}, at the moment the {request.Book.Name} is free, you can take. \n" +
                $"You have a 15 minute head start because you are next in line. "
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync($"smtp.{EmailSettings.Email.Split('@')[1]}", 465, true);
                await client.AuthenticateAsync(EmailSettings.Email, EmailSettings.Password);
                await client.SendAsync(message);

                await client.DisconnectAsync(true);
            }

            return Unit.Value;
        }
    }
}
