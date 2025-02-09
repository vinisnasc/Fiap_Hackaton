using Fiap_Hackaton.Health_Med.Domain.Entities;
using Fiap_Hackaton.Health_Med.Domain.Models.Agendamento;

namespace Fiap_Hackaton.Health_Med.Domain.Interfaces.Repository
{
    public interface IAgendamentoRepository : IBaseRepository<Agendamento>
    {
        Task<List<MedicoDisponibilidade>> ObterMedicosDisponiveis(string especializacao, DateTime data);
        Task<List<SolicitacaoAgendamento>> VisualizarAgendamentosSolicitadosMedico(Guid idMedico);
        Task<List<SolicitacaoAgendamento>> VisualizarAgendamentosSolicitadosPaciente(Guid idPaciente);
    }
}
