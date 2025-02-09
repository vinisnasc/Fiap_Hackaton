using Fiap_Hackaton.Health_Med.Data.Contexto;
using Fiap_Hackaton.Health_Med.Domain.Entities;
using Fiap_Hackaton.Health_Med.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fiap_Hackaton.Health_Med.Data.Repository
{
    public class DisponibilidadeRepository : BaseRepository<Disponibilidade>, IDisponibilidadeRepository
    {
        public DisponibilidadeRepository(AppDbContexto context) : base(context)
        {
        }

        public async Task<Disponibilidade> BuscarPorIdMedicoEDia(Guid id, int dia)
        {
            if (dia == 0) dia = 1;

            return await _dbSet.FirstOrDefaultAsync(x => x.IdMedico == id && x.DiaSemana == dia);
        }

        public async Task<List<Disponibilidade>> BuscarPorIdMedico(Guid id)
        {
            return await _dbSet.Where(x => x.IdMedico == id).ToListAsync();
        }
    }
}
