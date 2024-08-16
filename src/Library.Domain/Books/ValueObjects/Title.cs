using Library.Domain.Core.BaseType;
using Library.Domain.Core.BaseType.Results;

namespace Library.Domain.Books.ValueObjects;

public sealed class Title : ValueObject
{
    public const int MaxLength = 100;

    private Title(string value) => Value = value;

    public string Value { get; }

    public static Result<Title> Create(string title) =>
        Result.Create(title, Error.None)
              .Ensure(t => string.IsNullOrEmpty(t), Error.None)
              .Ensure(t => t.Length > MaxLength, Error.None)
              .Map(t => new Title(t));

    public override string ToString() => Value;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
