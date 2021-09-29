using System;
using System.Collections.Generic;

namespace Notification.Data.Entities
{
    public class User : EntityBase
    {
        public Guid mainId { get; set; }
        public Guid Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
