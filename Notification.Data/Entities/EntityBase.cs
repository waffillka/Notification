using Notification.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Notification.Data.Entities
{
    public abstract class EntityBase : IIdentifiable<Guid>, ISoftDeleteable
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
