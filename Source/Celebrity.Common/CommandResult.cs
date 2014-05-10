using System;

namespace Celebrity
{
    public class CommandResult : IMessage
    {
        public Guid CorrelationId { get; set; }
    }
}