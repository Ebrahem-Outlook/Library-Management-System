using Library.Domain.Core.Events;

namespace Library.Domain.Books.Events;

public sealed record BookCreatedDomainEvent(Book Book) : DomainEvent();
