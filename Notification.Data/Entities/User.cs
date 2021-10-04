using System;
using System.Collections.Generic;

namespace Notification.Data.Entities
{
    public class User : EntityBase
    {
        public Guid mainId { get; set; }
        public string UserName { get; set; }
        public string UserNickname { get; set; }
        public string UserEmail { get; set; }
        public ICollection<Guid> Books { get; set; }
    }
}
