namespace Notification.Data.Interfaces
{
    public interface IIdentifiable<TIdentifierType>
    {
        TIdentifierType Id { get; set; }
    }
}
