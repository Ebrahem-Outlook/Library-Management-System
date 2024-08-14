using Library.Application.Core.Abstractions.CQRS;

namespace Library.Application.Books.Commands.CreateBook;

/// <summary>
/// Command to create a new book in the library.
/// </summary>
public sealed record CreateBookCommand : ICommand
{
    /// <summary>
    /// Gets the title of the book.
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// Gets the author of the book.
    /// </summary>
    public string Author { get; init; }

    /// <summary>
    /// Gets the publisher of the book.
    /// </summary>
    public string Publisher { get; init; }

    /// <summary>
    /// Gets the number of pages in the book.
    /// </summary>
    public int PageCount { get; init; }

    /// <summary>
    /// Gets the summary of the book.
    /// </summary>
    public string Summary { get; init; }

    /// <summary>
    /// Gets the language of the book.
    /// </summary>
    public string Language { get; init; }

    /// <summary>
    /// Gets the publication year of the book.
    /// </summary>
    public DateTime PublicationYear { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateBookCommand"/> class.
    /// </summary>
    /// <param name="title">The title of the book.</param>
    /// <param name="author">The author of the book.</param>
    /// <param name="publisher">The publisher of the book.</param>
    /// <param name="pageCount">The number of pages in the book.</param>
    /// <param name="summary">The summary of the book.</param>
    /// <param name="language">The language of the book.</param>
    /// <param name="publicationYear">The publication year of the book.</param>
    public CreateBookCommand(
        string title,
        string author,
        string publisher,
        int pageCount,
        string summary,
        string language,
        DateTime publicationYear)
    {
        Title = title;
        Author = author;
        Publisher = publisher;
        PageCount = pageCount;
        Summary = summary;
        Language = language;
        PublicationYear = publicationYear;
    }
}
