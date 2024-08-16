using Library.Domain.Core.BaseType;
using Library.Domain.Core.BaseType.Results;

namespace Library.Domain.Books.ValueObjects;

public sealed class Summary : ValueObject
{
    public const int MaxLength = 2000;

    private Summary(string value ) => Value = value;

    public string Value { get; }

    public static Result<Summary> Create(string summary) =>
        Result.Create(summary, Error.None)
              .Ensure(s => string.IsNullOrEmpty(s), Error.None)
              .Ensure(t => t.Length < MaxLength, Error.None)
              .Map(t => new Summary(t));

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
