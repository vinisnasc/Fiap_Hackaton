using System.ComponentModel.DataAnnotations;

namespace Fiap_Hackaton.Identity.API.Models;

public class UsuarioLogin
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Identificacao { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public string Senha { get; set; }
}