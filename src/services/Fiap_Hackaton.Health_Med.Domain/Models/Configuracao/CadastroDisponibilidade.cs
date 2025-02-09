namespace Fiap_Hackaton.Health_Med.Domain.Models.Configuracao
{
    public class CadastroDisponibilidade
    {
        public int DiaSemana { get; set; }
        public TimeOnly HorarioInicio { get; set; }
        public TimeOnly HorarioFim { get; set; }
        public decimal ValorConsulta { get; set; }
    }
}
