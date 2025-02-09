using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap_Hackaton.Health_Med.Domain.Models.Agendamento
{
    public class SolicitacaoAgendamento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Horario { get; set; }
        public bool Aprovado { get; set; }
        public decimal Valor { get; set; }
    }
}
