namespace Library.API.Contracts.Book;

public sealed record CreateBookRequest(
    string Title, 
    string Author, 
    string Publisher, 
    string PageCount, 
    string Summary, 
    string Language, 
    string PublicationYear);

