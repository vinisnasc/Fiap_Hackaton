namespace Fiap_Hackaton.Health_Med.Domain.Entities
{
    internal class Agendamento
    {
        public Guid IdPaciente { get; set; }
        public Guid IdMedico { get; set; }
        public DateTime Horario { get; set; }
        public bool Aprovado { get; set; } // obs: quando o medico aprovar, desaprovar todos do mesmo horario
    }
}
