using System;

namespace Celebrity
{
    public interface IMessage
    {
        Guid CorrelationId { get; set; }
    }
}