using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fiap_Hackaton.Health_Med.Domain.Models.Auth
{
    public class RegistroMedico : RegistroUsuario
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Identificacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Especializacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirmacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
