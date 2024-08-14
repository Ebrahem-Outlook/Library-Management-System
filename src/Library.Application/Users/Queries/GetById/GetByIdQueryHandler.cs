using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Users;

namespace Library.Application.Users.Queries.GetById;

internal sealed class GetByIdQueryHandler : IQueryHandler<GetByIdQuery, User>
{
    public Task<User> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
