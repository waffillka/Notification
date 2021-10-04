using System;
using System.Collections.Generic;

namespace Notification.Data.Entities
{
    public class Book : EntityBase
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public ICollection<string> Authors { get; set; }

        public ICollection<Guid> Users { get; set; }
    }
}
