namespace Library.API.Contracts.User;

public sealed record UpdateUserRequest(Guid UserId, string FirstName, string LastName);
