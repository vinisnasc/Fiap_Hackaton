using Microsoft.AspNetCore.Identity;

namespace Fiap_Hackaton.Identity.API.Models
{
    public class UsuarioAplicacao : IdentityUser
    {
        public string Identificacao { get; set; }
        public string Especializacao { get; set; }
        public string Nome { get; set; }
        public string Teste { get; set; }
    }
}
