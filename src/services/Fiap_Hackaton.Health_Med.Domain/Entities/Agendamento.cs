namespace Fiap_Hackaton.Health_Med.Domain.Entities
{
    public class Agendamento : BaseEntity
    {
        public Guid IdPaciente { get; set; }
        public Guid IdMedico { get; set; }
        public DateTime Horario { get; set; }
        public bool? Aprovado { get; set; }
        public decimal Valor { get; set; }
    }
}
