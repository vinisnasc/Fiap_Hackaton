using Fiap_Hackaton.Health_Med.Domain.Models.Auth;

namespace Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;

public interface IAuthService
{
    Task<LoginResult> Logar(LoginModel model);
    Task<LoginResult> Registrar(RegistroPaciente model);
    Task<LoginResult> Registrar(RegistroMedico model);
}