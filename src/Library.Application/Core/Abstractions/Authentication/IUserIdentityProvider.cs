namespace Library.Application.Core.Abstractions.Authentication;

public interface IUserIdentityProvider
{
    Guid Id { get; }
}