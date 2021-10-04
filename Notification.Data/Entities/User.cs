using System;
using System.Collections.Generic;

namespace Notification.Data.Entities
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string UserNickname { get; set; }
        public string UserEmail { get; set; }

        public DateTime SubscriptionDate { get; set; } = DateTime.Now;
        public ICollection<Guid> Books { get; set; }
    }
}
