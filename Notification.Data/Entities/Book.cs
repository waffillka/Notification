using System.Collections.Generic;

namespace Notification.Data.Entities
{
    public class Book : EntityBase
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Authors { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
