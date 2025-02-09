using Fiap_Hackaton.Health_Med.Domain.Entities;
using Fiap_Hackaton.Health_Med.Domain.Interfaces.Repository;
using Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;
using Fiap_Hackaton.Health_Med.Domain.Models.Configuracao;

namespace Fiap_Hackaton.Health_Med.Services;

public class ConfiguracaoService : BaseService, IConfiguracaoService
{
    private readonly IDisponibilidadeRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public ConfiguracaoService(INotificator notificador, IDisponibilidadeRepository repository, ICurrentUserService currentUser) : base(notificador)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task CadastrarDisponibilidades(List<CadastroDisponibilidade> models)
    {
        if(models.Any(x => x.DiaSemana > 7 || x.DiaSemana < 1))
        {
            Notificate("Dia da semana invalido");
            return;
        }

        var cadastradas = await _repository.BuscarPorIdMedico(Guid.Parse(_currentUser.UserId));

        foreach (var model in models)
        {
            if(model.HorarioInicio > model.HorarioFim)
            {
                Notificate("Horario de inicio deve ser anterior ao horario final");
                return;
            }

            var cadastrada = cadastradas.FirstOrDefault(x => x.DiaSemana == model.DiaSemana);

            if (cadastrada is null) await _repository.IncluirAsync(new Disponibilidade
            {
                Id = Guid.NewGuid(),
                IdMedico = Guid.Parse(_currentUser.UserId),
                DiaSemana = model.DiaSemana,
                HorarioFinal = model.HorarioFim,
                HorarioInicial = model.HorarioInicio,
                ValorConsulta = model.ValorConsulta
            });

            else 
            { 
                cadastrada.HorarioInicial = model.HorarioInicio;
                cadastrada.HorarioFinal = model.HorarioFim;
                cadastrada.ValorConsulta = model.ValorConsulta;
                await _repository.Alterar(cadastrada);
            }
        }
    }

    public async Task<List<Disponibilidade>> DisponibilidadeCadastradas()
    {
        var result = await _repository.BuscarPorIdMedico(Guid.Parse(_currentUser.UserId));
        return result;
    }
}