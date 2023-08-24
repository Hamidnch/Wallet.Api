using MediatR;

namespace Wallet.Domain.Events;

public abstract class BaseEvent : INotification
{
    public DateTime OccurredAt { get; private set; } = DateTime.UtcNow;
}