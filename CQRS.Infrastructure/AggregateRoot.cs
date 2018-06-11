using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Infrastructure
{
    public class AggregateRoot
    {
        private readonly List<Event> _events;

        public AggregateRoot()
        {
            _events = new List<Event>();
        }

        public int Version { get; set; }

        public Guid Id { get; set; }

        public void ApplyChange<TEvent>(TEvent e) where TEvent : Event
        {
            ApplyInternalChange(e);
        }

        private void ApplyInternalChange<TEvent>(TEvent e, bool fromHistory = false) where TEvent : Event
        {
            if (e == null)
            {
                return;
            }

            if (!fromHistory)
            {
                _events.Add(e);
            }

            var handler = this as IHandle<TEvent>;
            if (handler == null)
            {
                throw new NotImplementedException($"The aggregate root {nameof(GetType)} does not have a handler for {nameof(TEvent)}");
            }

            handler.Handle(e);
        }

        public void LoadFromHistory(IEnumerable<Event> events)
        {
            var eventList = (events as List<Event> ?? new List<Event>()).OrderBy(x=>x.CreatedAt).ToList();
            
            if (eventList.Any())
            {
                eventList.ForEach(e => ApplyInternalChange(e, true));
                Version = eventList.Last().Version;
            }
        }
    }
}