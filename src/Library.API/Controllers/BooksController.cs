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
[ApiController]
[Route("api/v/{version:apiVersion}/[Controller]")]    
[ApiVersion("1.0.0")]
public sealed class BooksController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookRequest request) =>
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
    public async Task<IActionResult> Update([FromBody] UpdateBookRequest request) =>
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

    [HttpDelete("id:{bookId}")]
    public async Task<IActionResult> Delete(Guid bookId) => Ok(await sender.Send(new DeleteBookRequest(bookId)));

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllBooksQuery()));

    [HttpGet("id:{bookId}")]
    public async Task<IActionResult> GetById(Guid bookId) => Ok(await sender.Send(new GetByIdQuery(bookId)));

    [HttpGet("title:{title}")]
    public async Task<IActionResult> GetByTitle(string title) => Ok(await sender.Send(new GetByTitleQuery(title)));

    [HttpGet("author:{author}")]
    public async Task<IActionResult> GetByAuthor(string author) => Ok(await sender.Send(new GetByAuthorQuery(author)));
}
