namespace Application.Common.Events;

public class EventNotification<IEvent> : INotification
{
    public EventNotification(IEvent @event) => Event = @event;

    public IEvent Event { get; }
}