using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap_Hackaton.Health_Med.Domain.Entities
{
    public class AspNetUsers
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Especializacao { get; set; }
    }
}
