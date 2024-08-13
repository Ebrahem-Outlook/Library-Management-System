namespace Library.API.Contracts.User;

public sealed record UpdateEmailRequest(Guid UserId, string Email);
