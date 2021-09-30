using Notification.Contracts.Abstractions.Broker;
using System;

namespace Notification.Contracts.DataTransferObject.Broker
{
    public class FreeBook : IFreeBook
    {
        public Guid BookId { get; set; }
    }
}
