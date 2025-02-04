using Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_Hackaton.Health_Med.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    public AuthController(INotificator notificator) : base(notificator)
    {
    }

    [HttpGet]
    [Authorize(Roles = "Paciente")]
    public async Task<IActionResult> RetornaOk()
    {
        return Ok();
    }

    [HttpGet("teste")]
    [Authorize(Roles = "Medico")]
    public async Task<IActionResult> RetornaBadRequest()
    {
        return Ok();
    }
}