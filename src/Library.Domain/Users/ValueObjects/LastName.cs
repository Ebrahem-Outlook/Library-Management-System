using Library.Domain.Core.BaseType;
using Library.Domain.Core.BaseType.Results;

namespace Library.Domain.Users.ValueObjects;

public sealed class LastName : ValueObject
{
    public const int MaxLength = 100;

    private LastName(string value) => Value = value;

    public static LastName Creat(string lastName) => 
        Result.Create(lastName,  )

    public string Value { get; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}
