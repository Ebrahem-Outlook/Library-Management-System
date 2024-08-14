using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Users;

namespace Library.Application.Users.Queries.GetByEmail;

internal sealed class GetByEmailQueryHandler : IQueryHandler<GetByEmailQuery, User>
{
    public Task<User> Handle(GetByEmailQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
