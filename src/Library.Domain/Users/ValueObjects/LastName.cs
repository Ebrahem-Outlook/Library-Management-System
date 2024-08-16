using Library.Domain.Core.BaseType;
using Library.Domain.Core.BaseType.Results;

namespace Library.Domain.Users.ValueObjects;

public sealed class LastName : ValueObject
{
    public const int MaxLength = 100;

    private LastName(string value) => Value = value;

    public string Value { get; }

    public static Result<LastName> Create(string lastName) =>
        Result.Create(lastName, Error.None)
              .Ensure(l => !string.IsNullOrEmpty(l), Error.None)
              .Ensure(l => l.Length > MaxLength, Error.None)
              .Map(l => new LastName(l));

    public override string ToString() => Value;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
