using Library.Domain.Books.Events;
using Library.Domain.Core.BaseType;

namespace Library.Domain.Books
{
    /// <summary>
    /// Represents a book in the system, including its details and behavior.
    /// Inherits from <see cref="AggregateRoot"/> and raises domain events when created.
    /// </summary>
    public sealed class Book : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class with specified details.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="publisher">The publisher of the book.</param>
        /// <param name="pageCount">The number of pages in the book.</param>
        /// <param name="summary">A summary or description of the book.</param>
        /// <param name="languge">The language of the book.</param>
        /// <param name="publicationYear">The publication year of the book.</param>
        private Book(string title, string author, string publisher, int pageCount, string summary, string languge, DateTime publicationYear)
            : base(Guid.NewGuid())
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            PageCount = pageCount;
            Summary = summary;
            Languge = languge;
            PublicationYear = publicationYear;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class for use by EF Core.
        /// </summary>
        private Book() : base() { }

        /// <summary>
        /// Gets the Title of the book.
        /// </summary>
        public string Title { get; private set; } = default!;

        /// <summary>
        /// Gets the Author of the book.
        /// </summary>
        public string Author { get; private set; } = default!;

        /// <summary>
        /// Gets the Publisher of the book.
        /// </summary>
        public string Publisher { get; private set; } = default!;

        /// <summary>
        /// Gets the Number Of Pages in the book.
        /// </summary>
        public int PageCount { get; private set; } 

        /// <summary>
        /// Gets a Summary or description of the book.
        /// </summary>
        public string Summary { get; private set; } = default!;

        /// <summary>
        /// Gets the Language of the book.
        /// </summary>
        public string Languge { get; private set; } = default!;

        /// <summary>
        /// Gets the Publication year of the book.
        /// </summary>
        public DateTime PublicationYear { get; private set; }

        /// <summary>
        /// Creates a new instance of the <see cref="Book"/> class and raises a <see cref="BookCreatedDomainEvent"/>.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="publisher">The publisher of the book.</param>
        /// <param name="pageCount">The number of pages in the book.</param>
        /// <param name="summary">A summary or description of the book.</param>
        /// <param name="languge">The language of the book.</param>
        /// <param name="publicationYear">The publication year of the book.</param>
        /// <returns>A new <see cref="Book"/> instance.</returns>
        public static Book Create(string title, string author, string publisher, int pageCount, string summary, string languge, DateTime publicationYear)
        {
            Book book = new Book(title, author, publisher, pageCount, summary, languge, publicationYear);

            book.RaiseDomainEvent(new BookCreatedDomainEvent(book));

            return book;
        }

        /// <summary>
        /// Updates the details of the book.
        /// </summary>
        /// <param name="title">The new title of the book.</param>
        /// <param name="author">The new author of the book.</param>
        /// <param name="publisher">The new publisher of the book.</param>
        /// <param name="pageCount">The new number of pages in the book.</param>
        /// <param name="summary">The new summary or description of the book.</param>
        /// <param name="languge">The new language of the book.</param>
        /// <param name="publicationYear">The new publication year of the book.</param>
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
}
