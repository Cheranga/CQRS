using System;
using CQRS.Infrastructure;

namespace CQRS.Domain.Events
{
    public class DiaryEntryCreatedEvent : Event
    {
        public DiaryEntryCreatedEvent(Guid aggregateId, string title, DateTime from, DateTime to, string description)
            : base(aggregateId, 0)
        {
            Title = title;
            From = from;
            To = to;
            Description = description;
        }

        public string Title { get; }
        public DateTime From { get; }
        public DateTime To { get; }
        public string Description { get; }
    }
}