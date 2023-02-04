namespace Application.Common.Events;

// This is just a shorthand to make it a bit easier to create event handlers for specific events.
public interface IEventNotificationHandler<IEvent> : INotificationHandler<EventNotification<IEvent>>
{
}

public abstract class EventNotificationHandler<IEvent> : INotificationHandler<EventNotification<IEvent>>
{
    public async ValueTask Handle(EventNotification<IEvent> notification, CancellationToken cancellationToken) =>
        await Handle(notification.Event, cancellationToken);

    public abstract ValueTask Handle(IEvent @event, CancellationToken cancellationToken);
}