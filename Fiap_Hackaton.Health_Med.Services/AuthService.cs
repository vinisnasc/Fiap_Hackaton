using Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;
using System.Text;
using System;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Fiap_Hackaton.Health_Med.Domain.Models.Auth;

namespace Fiap_Hackaton.Health_Med.Services;

public class AuthService : BaseService, IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(INotificator notificador, HttpClient httpClient) : base(notificador)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResult> Registrar(string json)
    {
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://localhost:44342/api/identidade/nova-conta", content);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            Notificate(errorMessage);
            return null;
        }

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<LoginResult>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<LoginResult> Registrar(RegistroMedico model)
    {
        model.Identificacao = model.Identificacao.Replace("-", "/");

        var json = JsonSerializer.Serialize(model);

        return await Registrar(json);
    }

    public async Task<LoginResult> Registrar(RegistroPaciente model)
    {
        var json = JsonSerializer.Serialize(model);

        return await Registrar(json);
    }

    public async Task<LoginResult> Logar(LoginModel model)
    {
        var json = JsonSerializer.Serialize(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://localhost:44342/api/identidade/logar", content);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<LoginResult>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}