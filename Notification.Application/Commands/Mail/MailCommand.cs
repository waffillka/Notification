using MailKit.Net.Smtp;
using MediatR;
using Microsoft.Extensions.Options;
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

    public class MailCommandHandler : RequestHandlerBase<MailCommand, Unit>
    {
        private readonly EmailSettings _emailSettings;

        public MailCommandHandler(ILoggerManager logger, IOptions<EmailSettings> emailSettings)
            : base(logger)
        {
            _emailSettings = emailSettings.Value;
        }

        public async override Task<Unit> HandleInternalAsync(MailCommand request, CancellationToken cancellationToken)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailSettings.Name, _emailSettings.Email));
            message.To.Add(new MailboxAddress(request.User.Name, request.User.Email));
            message.Subject = $"{request.Book.Name} is free!";
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"{request.Book.Name} is free!\n" +
                $"Dear {request.User.Name}, at the moment the {request.Book.Name} is free, you can take."
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync($"smtp.{_emailSettings.Email.Split('@')[1]}", 465, true);
                await client.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);
                await client.SendAsync(message);

                await client.DisconnectAsync(true);
            }

            return Unit.Value;
        }
    }
}
