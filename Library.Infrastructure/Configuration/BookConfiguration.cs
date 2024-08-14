using Library.Domain.Books;
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

            builder.Property(book => book.Title)
                   .HasColumnName("Title")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(book => book.Author)
                   .HasColumnName("Author")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(book => book.Publisher)
                   .HasColumnName("Publisher")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(book => book.PageCount)
                   .HasColumnName("PageCount")
                   .IsRequired();

            builder.Property(book => book.Summary)
                   .HasColumnName("Summary")
                   .HasMaxLength(2000)
                   .IsRequired();

            builder.Property(book => book.PublicationYear)
                   .HasColumnName("PublicationYear")
                   .IsRequired();
        }
    }
}
