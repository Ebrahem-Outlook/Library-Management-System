using Library.Domain.Core.Events;

namespace Library.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(User User) : DomainEvent();
