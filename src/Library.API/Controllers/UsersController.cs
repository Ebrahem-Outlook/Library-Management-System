using Library.API.Contracts.User;
using Library.Application.Users.Commands.UpdateEmail;
using Library.Application.Users.Commands.UpdatePassword;
using Library.Application.Users.Commands.UpdateUser;
using Library.Application.Users.Queries.GetByEmail;
using Library.Application.Users.Queries.GetById;
using Library.Application.Users.Queries.GetByName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Authorize]
[ApiController]
[Route("api/v/{version:apiVersion}/[Controller]")]
[ApiVersion("1.0.0")]
public class UsersController(ISender sender) : ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request) =>
        Ok(await sender.Send(
            new UpdateUserCommand(
                request.FirstName, 
                request.LastName)));

    [HttpPut("email")]
    public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailRequest request) =>
        Ok(await sender.Send(
            new UpdateEmailCommand(
                request.UserId,
                request.Email)));

    [HttpPut("password")]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request) =>
        Ok(await sender.Send(
            new UpdatePasswordCommand(
                request.UserId, 
                request.Password)));

    [HttpGet("id:{userId}")]
    public async Task<IActionResult> GetById(Guid userId) => Ok(await sender.Send(new GetByIdQuery(userId)));

    [HttpGet("email:{email}")]
    public async Task<IActionResult> GetByEmail(string email) => Ok(await sender.Send(new GetByEmailQuery(email)));

    [HttpGet("name:{name}")]
    public async Task<IActionResult> GetByName(string name) => Ok(await sender.Send(new GetByNameQuery(name)));
}
