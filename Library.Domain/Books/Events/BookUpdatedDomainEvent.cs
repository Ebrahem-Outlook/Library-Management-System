using Library.Domain.Core.Events;

namespace Library.Domain.Books.Events;

public sealed record BookUpdatedDomainEvent(Book Book) : DomainEvent();
