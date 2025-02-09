using Fiap_Hackaton.Health_Med.Domain.Entities;
using Fiap_Hackaton.Health_Med.Domain.Models.Agendamento;

namespace Fiap_Hackaton.Health_Med.Domain.Interfaces.Services
{
    public interface IAgendaService
    {
        Task<List<MedicoDisponibilidade>> BuscarMedicos(string especializacao, DateTime data);
        Task SolicitarAgendamento(DateTime data, Guid idMedico);
        Task<List<SolicitacaoAgendamento>> VisualizarPedidos();
        Task<List<SolicitacaoAgendamento>> VisualizarPedidosPaciente();
        Task AprovarAgendamento(Guid id);
        Task RecusarAgendamento(Guid id);
    }
}
