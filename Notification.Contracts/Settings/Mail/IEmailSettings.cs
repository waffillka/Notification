namespace Notification.Contracts.Settings.Mail
{
    public interface IEmailSettings
    {
        string Email { get; set; }
        string Password { get; set; }
        string Name { get; set; }
    }
}
