using Library.API.Contracts.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Authorize]
[ApiController]
[Route("api/v/{version:apiVersion}[Controller]")]
[ApiVersion("1.0")]
public class UsersController(ISender sender) : ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request) =>
        Ok(await sender(
            new UpdateUserCommand(
                request.UserId, 
                request.FirstName, 
                request.LastName)));
}
