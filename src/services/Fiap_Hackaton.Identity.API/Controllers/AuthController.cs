using Fiap_Hackaton.Identity.API.Extensions;
using Fiap_Hackaton.Identity.API.Models;
using Fiap_Hackaton.Identity.API.Models.Constantes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap_Hackaton.Identity.API.Controllers;

[ApiController]
[Route("api/identidade")]
public class AuthController : ControllerBase
{
    private readonly SignInManager<UsuarioAplicacao> _signInManager;
    private readonly UserManager<UsuarioAplicacao> _userManager;
    private readonly AppSettings _appSettings;

    public AuthController(UserManager<UsuarioAplicacao> userManager, SignInManager<UsuarioAplicacao> signInManager, IOptions<AppSettings> appSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _appSettings = appSettings.Value;
    }

    [HttpPost("nova-conta")]
    public async Task<ActionResult> Registrar(UsuarioRegistro model)
    {
        if (!ModelState.IsValid) return BadRequest();

        var user = new UsuarioAplicacao
        {
            UserName = model.Email,
            NormalizedUserName = model.Email.ToUpper(),
            EmailConfirmed = true,
            Identificacao = model.Identificacao,
            Especializacao = model.Especializacao,
            Email = model.Email,
            Nome = model.Nome,
        };

        bool ehPaciente = false;

        if (CPFValidator.IsValid(model.Identificacao))
            ehPaciente = true;

        else if (CRMValidator.IsValid(model.Identificacao))
            ehPaciente = false;

        else return BadRequest("Identificacao Invalida!");

        var userExiste = await _userManager.FindByEmailAsync(user.Email);
        if (userExiste is not null) return BadRequest("Usuario já existe");

        var result = await _userManager.CreateAsync(user, model.Senha);

        if (!ehPaciente) await _userManager.AddToRoleAsync(user, Perfil.Medico);

        else await _userManager.AddToRoleAsync(user, Perfil.Paciente);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok(await GerarJwt(model.Email));
        }


        return BadRequest("Algo errado ocorreu!");
    }

    [HttpPost("logar")]
    public async Task<ActionResult> Login(UsuarioLogin model)
    {
        if (!ModelState.IsValid) return BadRequest();

        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Identificacao == model.Identificacao);

        if (user == null) return Unauthorized("Usuário não encontrado");

        var result = await _signInManager.PasswordSignInAsync(user, model.Senha, false, true);

        if (result.Succeeded) return Ok(await GerarJwt(user.Email));

        return BadRequest();
    }

    private async Task<UsuarioRespostaLogin> GerarJwt(string email)
    {
        var usuario = await _userManager.FindByEmailAsync(email);
        var claims = await _userManager.GetClaimsAsync(usuario);
        var userRoles = await _userManager.GetRolesAsync(usuario);

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, usuario.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

        foreach (var role in userRoles)
            claims.Add(new Claim("role", role));

        var identityClaims = new ClaimsIdentity();
        identityClaims.AddClaims(claims);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _appSettings.Emissor,
            Audience = _appSettings.ValidoEm,
            Subject = identityClaims,
            Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        });

        var encodedToken = tokenHandler.WriteToken(token);

        var response = new UsuarioRespostaLogin
        {
            AccessToken = encodedToken,
            ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
            UsuarioToken = new UsuarioToken
            {
                Id = usuario.Id,
                Claims = claims.Select(x => new UsuarioClaim { Type = x.Type, Value = x.Value })
            }
        };

        return response;
    }

    private static long ToUnixEpochDate(DateTime date)
        => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
}