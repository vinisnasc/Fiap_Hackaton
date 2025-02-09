using Fiap_Hackaton.Health_Med.Domain.Entities;

namespace Fiap_Hackaton.Health_Med.Domain.Interfaces.Repository;

public interface IDisponibilidadeRepository : IBaseRepository<Disponibilidade>
{
    Task<List<Disponibilidade>> BuscarPorIdMedico(Guid id);
    Task<Disponibilidade> BuscarPorIdMedicoEDia(Guid id, int dia);
}