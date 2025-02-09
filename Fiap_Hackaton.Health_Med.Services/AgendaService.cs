using Fiap_Hackaton.Health_Med.Domain.Entities;
using Fiap_Hackaton.Health_Med.Domain.Extensions;
using Fiap_Hackaton.Health_Med.Domain.Interfaces.Repository;
using Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;
using Fiap_Hackaton.Health_Med.Domain.Models.Agendamento;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fiap_Hackaton.Health_Med.Services
{
    public class AgendaService : BaseService, IAgendaService
    {
        private readonly IAgendamentoRepository _repository;
        private readonly IDisponibilidadeRepository _repositoryDisponibilidade;
        private readonly ICurrentUserService _currentUser;

        public AgendaService(INotificator notificador, IAgendamentoRepository repository, ICurrentUserService currentUser, IDisponibilidadeRepository repositoryDisponibilidade) : base(notificador)
        {
            _repository = repository;
            _currentUser = currentUser;
            _repositoryDisponibilidade = repositoryDisponibilidade;
        }

        public async Task<List<MedicoDisponibilidade>> BuscarMedicos(string especializacao, DateTime data)
        {
            if (data < DateTime.Now)
            {
                Notificate("Data deve ser maior que a data atual!");
                return null;
            }
            var result = await _repository.ObterMedicosDisponiveis(especializacao, data);
            return result;
        }

        public async Task SolicitarAgendamento(DateTime data, Guid idMedico)
        {
            data = data.ArredondarParaHoraAnterior();

            var existe = await _repository.Buscar(x => x.IdPaciente == Guid.Parse(_currentUser.UserId) && x.Horario == data && (x.Aprovado == null || x.Aprovado == true));

            if (existe is not null)
            {
                Notificate("Já existe um agendamento com esse horario!");
                return;
            }

            existe = await _repository.Buscar(x => x.IdMedico == idMedico && x.Horario == data && x.Aprovado == true);

            if (existe is not null)
            {
                Notificate("Medico indisponivel para este horario!");
                return;
            }

            var disponibilidade = await _repositoryDisponibilidade.BuscarPorIdMedicoEDia(idMedico, (int)data.DayOfWeek);

            await _repository.IncluirAsync(new Agendamento()
            {
                Id = Guid.NewGuid(),
                IdMedico = idMedico,
                IdPaciente = Guid.Parse(_currentUser.UserId),
                Horario = data,
                Valor = disponibilidade.ValorConsulta
            });
        }

        public async Task<List<SolicitacaoAgendamento>> VisualizarPedidos()
        {
            var todos = await _repository.VisualizarAgendamentosSolicitadosMedico(Guid.Parse(_currentUser.UserId));

            return todos;
        }

        public async Task<List<SolicitacaoAgendamento>> VisualizarPedidosPaciente()
        {
            var todos = await _repository.VisualizarAgendamentosSolicitadosPaciente(Guid.Parse(_currentUser.UserId));



            return todos;
        }

        public async Task AprovarAgendamento(Guid id)
        {
            var agendamento = await _repository.SelecionarPorId(id);

            var todosSemelhantes = await _repository.BuscarVarios(x => x.IdMedico == Guid.Parse(_currentUser.UserId) && x.Horario == agendamento.Horario);

            foreach (var agend in todosSemelhantes)
            {
                if (agend.Id == agendamento.Id)
                    agend.Aprovado = true;

                else
                    agend.Aprovado = false;

                await _repository.Alterar(agend);
            }
        }

        public async Task RecusarAgendamento(Guid id)
        {
            var agendamento = await _repository.SelecionarPorId(id);

            if (agendamento is null)
            {
                Notificate("Agendamento nao encontrado");
                return;
            }

            if(agendamento.Aprovado == false)
            {
                Notificate("Agendamento já está recusado");
                return;
            }

            agendamento.Aprovado = false;

            await _repository.Alterar(agendamento);

        }
    }
}
