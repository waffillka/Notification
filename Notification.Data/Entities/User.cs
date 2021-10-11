using System;
using System.Collections.Generic;

namespace Notification.Data.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            Books = new List<Guid>();
        }

        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }

        public DateTime SubscriptionDate { get; set; } = DateTime.Now;
        public ICollection<Guid> Books { get; set; }
    }
}
