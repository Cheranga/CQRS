using System;
using System.Collections.Generic;

namespace CQRS.Infrastructure
{
    public class InMemoryBus: IBus
    {
        private readonly Dictionary<Type, List<IEventHandler<Event>>> _eventHandlers;

        public InMemoryBus()
        {
            _eventHandlers = new Dictionary<Type, List<IEventHandler<Event>>>();
        }

        public void RegisterHandlerFor<TEvent>(IEventHandler<TEvent> handler) where TEvent : Event
        {
            List<IEventHandler<Event>> handlers;
            if (_eventHandlers.TryGetValue(typeof(TEvent), out handlers))
            {
                handlers.Add(handler as IEventHandler<Event>);
            }
            else
            {
                _eventHandlers.Add(typeof(TEvent), new List<IEventHandler<Event>>(new [] {handler as IEventHandler<Event>}));
            }
        }

        public void Publish<TEvent>(TEvent e) where TEvent:Event
        {
            if (e == null)
            {
                return;
            }

            var handlers = GetHandlersFor<TEvent>();
            handlers.ForEach(x=>x.Handle(e));
        }

        private List<IEventHandler<Event>> GetHandlersFor<TEvent>() where TEvent:Event
        {
            List<IEventHandler<Event>> handlers;
            if (_eventHandlers.TryGetValue(typeof(TEvent), out handlers))
            {
                return handlers;
            }

            return new List<IEventHandler<Event>>();
        }
    }
}