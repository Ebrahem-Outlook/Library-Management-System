namespace Library.API.Contracts.Book;

public sealed record UpdateBookRequest(
    Guid BookId,
    string Title,
    string Author,
    string Publisher,
    string PageCount,
    string Summary,
    string Language,
    string PublicationYear);

