using Notification.Data.Interfaces;
using System;

namespace Notification.Data.Entities
{
    public abstract class EntityBase : IIdentifiable<Guid>, ISoftDeleteable
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
