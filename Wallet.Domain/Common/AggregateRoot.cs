using Wallet.Domain.Events;

namespace Wallet.Domain.Common
{
    public abstract class AggregateRoot : BaseEntity<Guid>
    {
        private readonly List<BaseEvent> _domainEvents = new List<BaseEvent>();

        public IReadOnlyList<BaseEvent> GetDomainEvents()
        {
            return _domainEvents.AsReadOnly();
        }

        protected void AddDomainEvent(BaseEvent domainEvent)
        {
            AddEvent(domainEvent);
            _domainEvents.Add(domainEvent);
        }

        public abstract void AddEvent(BaseEvent domainEvent);

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}