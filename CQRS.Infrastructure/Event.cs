using System;

namespace CQRS.Infrastructure
{
    public class Event
    {
        public Guid AggregateId { get; }
        public int Version { get; }
        public DateTime CreatedAt { get; set; }

        public Event(Guid aggregateId, int version)
        {
            AggregateId = aggregateId;
            Version = version;
            CreatedAt = DateTime.UtcNow;
        }
    }
}