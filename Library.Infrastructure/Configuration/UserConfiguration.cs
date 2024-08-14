using Library.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configuration;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Configuration Table Name.
        builder.ToTable("User", "User_Schema_1");

        // Configuration Primary Key.
        builder.HasKey(user => user.Id);

        // Configuraiton FirstName.
        builder.Property(user => user.FirstName)
               .HasColumnName(nameof(User.FirstName))
               .HasMaxLength(50)
               .IsRequired();

        // Configuraiotn LastName.
        builder.Property(user => user.LastName)
               .HasColumnName(nameof(User.LastName))
               .HasMaxLength(50)
               .IsRequired();

        // Configuration Email.
        builder.Property(user => user.Email)
               .HasColumnName(nameof(User.Email))
               .HasMaxLength(100)
               .IsRequired();

        // Configuration Password.
        builder.Property(user => user.PasswordHash)
               .HasColumnName(nameof(User.PasswordHash))
               .HasMaxLength(255)
               .IsRequired();
    }
}

