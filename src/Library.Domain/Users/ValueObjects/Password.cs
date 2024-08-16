using Library.Domain.Core.BaseType;
using Library.Domain.Core.BaseType.Results;

namespace Library.Domain.Users.ValueObjects;

public sealed class Password : ValueObject
{
    public const int MaxLength = 255;

    private Password(string value) => Value = value;

    public string Value { get; }

    public static Result<Password> Create(string passwordHash) =>
        Result.Create(passwordHash, Error.None)
              .Ensure(p => string.IsNullOrEmpty(passwordHash), Error.None)
              .Ensure(p => p.Length <= MaxLength, Error.None)
              .Map(p => new Password(p));

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
