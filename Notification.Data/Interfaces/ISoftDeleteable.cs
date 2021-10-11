namespace Notification.Data.Interfaces
{
    public interface ISoftDeleteable
    {
        public bool IsDeleted { get; set; }
    }
}
