using Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;
using Fiap_Hackaton.Health_Med.Domain.Models.Configuracao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_Hackaton.Health_Med.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracaoController : BaseController
    {
        private readonly IConfiguracaoService _configuracaoService;

        public ConfiguracaoController(INotificator notificator, IConfiguracaoService configuracaoService) : base(notificator)
        {
            _configuracaoService = configuracaoService;
        }

        [HttpGet("DisponibilidadesCadastradas")]
        [Authorize(Roles = "Medico")]
        public async Task<IActionResult> VerificarDisponibilidadeCadastrada()
        {
            var result = await _configuracaoService.DisponibilidadeCadastradas();
            return CustomResponse(result);
        }

        [HttpPost("CadastrarDisponibilidades")]
        [Authorize(Roles = "Medico")]
        public async Task<IActionResult> VerificarDisponibilidadeCadastrada(List<CadastroDisponibilidade> models)
        {
            await _configuracaoService.CadastrarDisponibilidades(models);
            return CustomResponse();
        }
    }
}
