using Library.API.Contracts.Auth;
using Library.Application.Authentication.Login;
using Library.Application.Authentication.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("api/1.0.0/[Controller]")]
public sealed class AuthController(ISender sender) : ControllerBase
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request) =>
        Ok(await sender.Send(
            new LoginCommand(
                request.Email, 
                request.Password)));

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest request) => 
        Ok(await sender.Send(
            new RegisterCommand(
                request.Email, 
                request.Password)));
}
