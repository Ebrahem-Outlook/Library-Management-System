using Library.Domain.Books.Events;
using Library.Domain.Core.BaseType;

namespace Library.Domain.Books;

/// <summary>
/// 
/// </summary>
public sealed class Book : AggregateRoot
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="author"></param>
    /// <param name="publisher"></param>
    /// <param name="pageCount"></param>
    /// <param name="summary"></param>
    /// <param name="languge"></param>
    /// <param name="publicationYear"></param>
    private Book(string title, string author, string publisher, int pageCount, string summary, string languge, DateTime publicationYear)
    {
        Title = title;
        Author = author;
        Publisher = publisher;
        PageCount = pageCount;
        Summary = summary;
        Languge = languge;
        PublicationYear = publicationYear;
    }

    private Book() : base() { }

    /// <summary>
    /// 
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string Author { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string Publisher { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int PageCount { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string Summary { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string Languge { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime PublicationYear { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="author"></param>
    /// <param name="publisher"></param>
    /// <param name="summary"></param>
    /// <param name="pageCount"></param>
    /// <param name="languge"></param>
    /// <param name="publicationYear"></param>
    /// <returns></returns>
    public static Book Create(string title, string author, string publisher, int pageCount, string summary, string languge, DateTime publicationYear)
    {
        Book book = new Book(title, author, publisher, pageCount, summary, languge, publicationYear);

        book.RaiseDomainEvent(new BookCreatedDomainEvent(book));

        return book;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="author"></param>
    /// <param name="publisher"></param>
    /// <param name="pageCount"></param>
    /// <param name="summary"></param>
    /// <param name="languge"></param>
    /// <param name="publicationYear"></param>
    public void Update(string title, string author, string publisher, int pageCount, string summary, string languge, DateTime publicationYear)
    {
        Title = title;
        Author = author;
        Publisher = publisher;
        PageCount = pageCount;
        Summary = summary; 
        Languge = languge;
        PublicationYear = publicationYear;
    }
}
