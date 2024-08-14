using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Users;

namespace Library.Application.Users.Queries.GetByName;

internal sealed class GetByNameQueryHandler : IQueryHandler<GetByNameQuery, User>
{
    public Task<User> Handle(GetByNameQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
