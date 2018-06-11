namespace CQRS.Infrastructure
{
    public interface IBus
    {
        void Publish<TEvent>(TEvent e) where TEvent : Event;
    }
}