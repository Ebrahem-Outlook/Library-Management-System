using Library.Domain.Core.Events;

namespace Library.Domain.Users.Events;

public sealed record UserUpdatedDomainEvent(User User) : DomainEvent();
