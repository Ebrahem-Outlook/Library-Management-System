using Library.Domain.Books;
using Library.Domain.Books.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configuration
{
    internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book","Book_Schema_1");

            builder.HasKey(book => book.Id);

            // Configure Title.
            builder.OwnsOne(book => book.Title, bookBuilder =>
            {
                bookBuilder.WithOwner();

                bookBuilder.Property(book => book.Value)
                           .HasColumnName(nameof(Book.Title))
                           .HasMaxLength(Title.MaxLength)
                           .IsRequired();
            });

            // Configure Author.
            builder.OwnsOne(book => book.Author, bookBuilder =>
            {
                bookBuilder.WithOwner();

                bookBuilder.Property(book => book.Value)
                           .HasColumnName(nameof(Book.Author))
                           .HasMaxLength(Author.MaxLength)
                           .IsRequired();
            });

            // Configure Summary.
            builder.OwnsOne(book => book.Summary, bookBuilder =>
            {
                bookBuilder.WithOwner();

                bookBuilder.Property(book => book.Value)
                           .HasColumnName(nameof(Book.Summary))
                           .HasMaxLength(Summary.MaxLength)
                           .IsRequired();
            });

            // Configure PageCount.
            builder.Property(book => book.PageCount)
                   .HasColumnName(nameof(Book.PageCount))
                   .IsRequired();

            // Configure Publisher.
            builder.OwnsOne(book => book.Publisher, bookBuilder =>
            {
                bookBuilder.WithOwner();

                bookBuilder.Property(book => book.Value)
                           .HasColumnName(nameof(Book.Publisher))
                           .HasMaxLength(Publisher.MaxLength)
                           .IsRequired();
            });

            // Configure Publication Year.
            builder.Property(book => book.PublicationYear)
                   .HasColumnName("PublicationYear")
                   .IsRequired();
        }
    }
}
