using Fiap_Hackaton.Health_Med.Domain.Entities;
using Fiap_Hackaton.Health_Med.Domain.Models.Configuracao;

namespace Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;

public interface IConfiguracaoService
{
    Task<List<Disponibilidade>> DisponibilidadeCadastradas();
    Task CadastrarDisponibilidades(List<CadastroDisponibilidade> models);
}