namespace Notification.Contracts.Settings.Mail
{
    public class EmailSettings : IEmailSettings
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
