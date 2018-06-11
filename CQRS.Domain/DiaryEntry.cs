using System;
using CQRS.Domain.Events;
using CQRS.Infrastructure;

namespace CQRS.Domain
{
    public class DiaryEntry : AggregateRoot, IHandle<DiaryEntryCreatedEvent>
    {
        public string Title { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Description { get; set; }

        public DiaryEntry(Guid id, string title, DateTime from, DateTime to, string description)
        {
            //
            // Call the aggregate to save the event, and internally it will call the appropriate IHandle<TEvent> implementation
            //
            ApplyChange(new DiaryEntryCreatedEvent(id, title, from, to, description));
        }

        public void Handle(DiaryEntryCreatedEvent e)
        {
            Id = e.AggregateId;
            Title = e.Title;
            From = e.From;
            To = e.To;
            Description = e.Description;
        }
    }
}