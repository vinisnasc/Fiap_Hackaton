using Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;
using Fiap_Hackaton.Health_Med.Domain.Models.Auth;
using Fiap_Hackaton.Health_Med.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_Hackaton.Health_Med.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(INotificator notificator, IAuthService authService) : base(notificator)
    {
        _authService = authService;
    }

    [HttpPost("RegistroPaciente")]
    //
    public async Task<IActionResult> RegistraPaciente(RegistroPaciente registroPaciente)
    {
        var result = await _authService.Registrar(registroPaciente);
        return CustomResponse(result);
    }

    [HttpPost("RegistroMedico")]
    public async Task<IActionResult> RegistraMedico(RegistroMedico registroMedico)
    {
        var result = await _authService.Registrar(registroMedico);
        return Ok();// CustomResponse(result);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var result = await _authService.Logar(model);
        return CustomResponse(result);
    }
}