namespace Library.API.Contracts.User;

public sealed record UpdatePasswordRequest(Guid UserId, string Password);
