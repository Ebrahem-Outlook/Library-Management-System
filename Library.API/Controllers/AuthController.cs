using Library.API.Contracts.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("v1/[Controller]")]
[ApiController]
public sealed class AuthController(ISender sender) : ControllerBase
{
    public async Task<IActionResult> Login(LoginRequest request) =>
        Ok();
}
