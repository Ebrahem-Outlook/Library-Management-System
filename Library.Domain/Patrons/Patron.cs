using Library.Domain.Core.BaseType;

namespace Library.Domain.Patrons;

public sealed class Patron : AggregateRoot
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public Address Address { get; private set; }
    public ICollection<BorrwingRecord> BorrowingRecords { get; }
}
