using Library.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configuration
{
    /// <summary>
    /// Configures the <see cref="User"/> entity for the database.
    /// </summary>
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configures the <see cref="User"/> entity using the provided <see cref="EntityTypeBuilder{User}"/>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the <see cref="User"/> entity.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configure the table name and schema.
            builder.ToTable("User", "User_Schema_1");

            // Configure the primary key.
            builder.HasKey(user => user.Id);

            // Configure the FirstName property.
            builder.Property(user => user.FirstName)
                   .HasColumnName(nameof(User.FirstName))
                   .HasMaxLength(50)
                   .IsRequired();

            // Configure the LastName property.
            builder.Property(user => user.LastName)
                   .HasColumnName(nameof(User.LastName))
                   .HasMaxLength(50)
                   .IsRequired();

            // Configure the Email property.
            builder.Property(user => user.Email)
                   .HasColumnName(nameof(User.Email))
                   .HasMaxLength(100)
                   .IsRequired();

            // Configure an index on the Email property.
            builder.HasIndex(user => user.Email);

            // Configure the PasswordHash property.
            builder.Property(user => user.PasswordHash)
                   .HasColumnName(nameof(User.PasswordHash))
                   .HasMaxLength(255)
                   .IsRequired();

            // Ignore the DomainEvents property.
            builder.Ignore(user => user.DomainEvents);
        }
    }
}
