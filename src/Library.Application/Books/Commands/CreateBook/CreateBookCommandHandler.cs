using Library.Application.Core.Abstractions.CQRS;
using Library.Domain.Core.BaseType.Results;
using Library.Domain.Users;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook;

internal sealed class CreateBookCommandHandler : ICommandHandler<CreateBookCommand>
{
}
