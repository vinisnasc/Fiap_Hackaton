namespace Fiap_Hackaton.Health_Med.Domain.Entities;

public class Disponibilidade : BaseEntity
{
    public Guid IdMedico { get; set; }
    public int DiaSemana { get; set; }
    public TimeOnly HorarioInicial { get; set; }
    public TimeOnly HorarioFinal { get; set; }
    public decimal ValorConsulta { get; set; }
}