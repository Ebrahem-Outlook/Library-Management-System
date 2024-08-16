using Library.Domain.Books.Events;
using Library.Domain.Books.ValueObjects;
using Library.Domain.Core.Abstractions;
using Library.Domain.Core.BaseType;

namespace Library.Domain.Books
{
    public sealed class Book : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
    {
        private Book(Title title, Author author, Summary summary, Languge languge, Publisher publisher, int pageCount, DateTime publicationYear)
        {
            Title = title;
            Author = author;
            Summary = summary;
            Languge = languge;
            Publisher = publisher;
            PageCount = pageCount;
            PublicationYear = publicationYear;
            CreatedOnUtc = DateTime.UtcNow;
        }

        private Book() : base() { }


        public Title Title { get; private set; } = default!;

        public Author Author { get; private set; } = default!;

        public Summary Summary { get; private set; } = default!;

        public Languge Languge { get; private set; } = default!;

        public Publisher Publisher { get; private set; } = default!;

        public int PageCount { get; private set; }

        public DateTime PublicationYear { get; private set; }

        public DateTime CreatedOnUtc { get; }

        public DateTime? ModifiedOnUtc { get; private set; }

        public DateTime? DeletedOnUtc { get; private set; }

        public bool Deleted { get; }


        public static Book Create(Title title, Author author, Summary summary, Languge languge, Publisher publisher, int pageCount, DateTime publicationYear)
        {
            Book book = new Book(title, author, summary, languge, publisher, pageCount, publicationYear);

            book.RaiseDomainEvent(new BookCreatedDomainEvent(book));

            return book;
        }

        public void Update(Title title, Author author, Summary summary, Languge languge, Publisher publisher, int pageCount, DateTime publicationYear)
        {
            Title = title;
            Author = author;
            Summary = summary;
            Languge = languge;
            Publisher = publisher;
            PageCount = pageCount;
            PublicationYear = publicationYear;

            RaiseDomainEvent(new BookUpdatedDomainEvent(this));
        }
    }
}
