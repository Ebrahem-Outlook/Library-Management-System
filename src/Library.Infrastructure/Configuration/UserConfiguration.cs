using Library.Domain.Users;
using Library.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configuration
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
    
            builder.ToTable("User", "User_Schema_1");


            builder.HasKey(user => user.Id);

            // Configure FirstName.
            builder.OwnsOne(user => user.FirstName, firstNameBuilder =>
            {
                firstNameBuilder.WithOwner();

                firstNameBuilder.Property(firstName => firstName.Value)
                                .HasColumnName(nameof(User.FirstName))
                                .HasMaxLength(FirstName.MaxLength)
                                .IsRequired();
            });

            // Configure LastName.
            builder.OwnsOne(lastName => lastName.LastName, lastNameBuilder =>
            {
                lastNameBuilder.WithOwner();

                lastNameBuilder.Property(lastName => lastName.Value)
                               .HasColumnName(nameof(User.LastName))
                               .HasMaxLength(LastName.MaxLength)
                               .IsRequired();
            });

            // Configure Email.
            builder.OwnsOne(email => email.Email, emailBuilder =>
            {
                emailBuilder.WithOwner();

                // builder.HasIndex(user => user.Email);

                emailBuilder.Property(email => email.Value)
                            .HasColumnName(nameof(User.Email))
                            .HasMaxLength(Email.MaxLength)
                            .IsRequired();
            });

            // Configure Password.
            builder.OwnsOne(user => user.PasswordHash, passwordHashBuilder =>
            {
                passwordHashBuilder.WithOwner();

                passwordHashBuilder.Property(password => password.Value)
                                   .HasColumnName(nameof(User.PasswordHash))
                                   .HasMaxLength(Password.MaxLength)
                                   .IsRequired();
            });

            // Ignore the DomainEvents property.
            builder.Ignore(user => user.DomainEvents);
        }
    }
}
