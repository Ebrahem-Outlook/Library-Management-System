using Library.Application.Core.Abstractions.Encreption;

namespace Library.Infrastructure.Cryptography;

internal sealed class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        throw new NotImplementedException();
    }
}
