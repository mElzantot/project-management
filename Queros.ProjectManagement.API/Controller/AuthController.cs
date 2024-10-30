using Microsoft.AspNetCore.Mvc;
using Queros.ProjectManagement.DTOs;
using Queros.ProjectManagement.Services;

namespace Queros.ProjectManagement.Controller;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthenticationService _authenticationService;

    public AuthController(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(AuthRequest authRequestDTO)
    {
        if (await _authenticationService.CheckIfUserNameExist(authRequestDTO.UserName))
            return BadRequest(new { Errors = "User Name is already exist , Please try another one" });
        var userToken = await _authenticationService.Register(authRequestDTO);
        return Ok(userToken);
    }

    [HttpPost]
    public async Task<IActionResult> Login(AuthRequest loginRequest)
    {
        var tokens = await _authenticationService.Login(loginRequest);
        return tokens == null ? BadRequest("User Name or Password is incorrect") : Ok(tokens);
    }
}