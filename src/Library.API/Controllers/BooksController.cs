using Library.API.Contracts.Book;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Queries.GetAll;
using Library.Application.Books.Queries.GetByAuthor;
using Library.Application.Books.Queries.GetById;
using Library.Application.Books.Queries.GetByTitle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Authorize]
[Route("api/[Controller]")]
[ApiController]
[ApiVersion("V1")]
public sealed class BooksController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateBookRequest request) =>
        Ok(await sender.Send(
            new CreateBookCommand(
                request.Title, 
                request.Author, 
                request.Publisher, 
                request.PageCount, 
                request.Summary, 
                request.Language, 
                request.PublicationYear)));

    [HttpPut]
    public async Task<IActionResult> Update(UpdateBookRequest request) =>
        Ok(await sender.Send(
            new UpdateBookRequest(
                request.BookId,
                request.Title,
                request.Author,
                request.Publisher,
                request.PageCount,
                request.Summary,
                request.Language,
                request.PublicationYear)));

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid BookId) => Ok(await sender.Send(new DeleteBookRequest(BookId)));

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllBooksQuery()));

    [HttpGet("id:{id}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await sender.Send(new GetByIdQuery(id)));

    [HttpGet("title:{title}")]
    public async Task<IActionResult> GetByTitle(string title) => Ok(await sender.Send(new GetByTitleQuery(title)));

    [HttpGet("author:{author}")]
    public async Task<IActionResult> GetByAuthor(string author) => Ok(await sender.Send(new GetByAuthorQuery(author)));
}
