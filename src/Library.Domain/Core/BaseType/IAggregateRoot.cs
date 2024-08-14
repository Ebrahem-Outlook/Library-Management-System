using Library.Domain.Core.Events;

namespace Library.Domain.Core.BaseType;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void RaiseDomainEvent(IDomainEvent @event);
    void ClearDomainEvent();
}
