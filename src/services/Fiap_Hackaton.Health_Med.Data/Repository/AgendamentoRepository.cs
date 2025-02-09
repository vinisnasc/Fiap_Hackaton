using Dapper;
using Fiap_Hackaton.Health_Med.Data.Contexto;
using Fiap_Hackaton.Health_Med.Domain.Entities;
using Fiap_Hackaton.Health_Med.Domain.Interfaces.Repository;
using Fiap_Hackaton.Health_Med.Domain.Models.Agendamento;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Fiap_Hackaton.Health_Med.Data.Repository
{
    public class AgendamentoRepository : BaseRepository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(AppDbContexto context) : base(context)
        {
        }

        public async Task<List<SolicitacaoAgendamento>> VisualizarAgendamentosSolicitadosMedico(Guid idMedico)
        {
            using var connection = _context.Database.GetDbConnection();

            string sql = @"
        select CAST(a.Id AS uniqueidentifier) AS Id, b.Nome, a.Horario, a.Aprovado from agendamentos a
Join AspNetUsers b on a.IdPaciente = b.Id
where a.IdMedico = @IdMedico";

            var result = await connection.QueryAsync<SolicitacaoAgendamento>(sql, new
            {
                IdMedico = idMedico
            });

            return result.ToList();
        }

        public async Task<List<SolicitacaoAgendamento>> VisualizarAgendamentosSolicitadosPaciente(Guid idPaciente)
        {
            using var connection = _context.Database.GetDbConnection();

            string sql = @"
        select CAST(a.Id AS uniqueidentifier) AS Id, b.Nome, a.Horario, a.Aprovado, A.Valor from agendamentos a
Join AspNetUsers b on a.IdPaciente = b.Id
where a.IdPaciente = @IdPaciente";

            var result = await connection.QueryAsync<SolicitacaoAgendamento>(sql, new
            {
                IdPaciente = idPaciente
            });

            return result.ToList();
        }

        public async Task<List<MedicoDisponibilidade>> ObterMedicosDisponiveis(string especializacao, DateTime data)
        {
            TimeSpan horario = data.TimeOfDay;
            int diaSemana = (int)data.DayOfWeek == 0 ? 7 : (int)data.DayOfWeek;

            using var connection = _context.Database.GetDbConnection();

            string sql = @"
        SELECT a.Id, a.Nome, a.Especializacao
        FROM AspNetUsers a
        JOIN Disponibilidades b ON a.Id = b.IdMedico
        WHERE a.Especializacao = @Especializacao
          AND b.DiaSemana = @DiaSemana
          AND @Horario BETWEEN b.HorarioInicial AND b.HorarioFinal";

            var result = await connection.QueryAsync<MedicoDisponibilidade>(sql, new
            {
                Especializacao = especializacao,
                DiaSemana = diaSemana,
                Horario = horario
            });

            return result.ToList();
        }

        //public async Task<List<MedicoDisponibilidade>> ObterMedicosDisponiveis(string especializacao, DateTime data)
        //{
        //    TimeSpan horario = data.TimeOfDay;
        //    int diaSemana = (int)data.DayOfWeek;

        //    if (diaSemana == 0)
        //        diaSemana = 7;

        //    //       var result = await _context.Disponibilidades
        //    //.FromSqlRaw(@"SELECT b.* 
        //    //              FROM AspNetUsers a
        //    //              JOIN Disponibilidades b ON a.Id = b.IdMedico
        //    //              WHERE a.Especializacao = {0} 
        //    //                AND b.DiaSemana = {1} 
        //    //                AND {2} BETWEEN b.HorarioInicial AND b.HorarioFinal",
        //    //            especializacao, diaSemana, horario)
        //    //.ToListAsync();
        //    var result = await _context.Usuarios // Troque `Medicos` pela entidade correta no seu `DbContext`
        //        .FromSqlRaw(@"SELECT a.Id as IdMedico, a.Nome, a.Especializacao, 
        //                     b.DiaSemana, b.HorarioInicial, b.HorarioFinal
        //              FROM AspNetUsers a
        //              JOIN Disponibilidades b ON a.Id = b.IdMedico
        //              WHERE a.Especializacao = {0} 
        //                AND b.DiaSemana = {1} 
        //                AND {2} BETWEEN b.HorarioInicial AND b.HorarioFinal",
        //                      especializacao, diaSemana, horario)
        //        .Select(m => new MedicoDisponibilidade
        //        {
        //            Id = m.Id,
        //            Nome = m.Nome,
        //            Especializacao = m.Especializacao,
        //        })
        //        .ToListAsync();

        //    return result;
        //}


    }
}
