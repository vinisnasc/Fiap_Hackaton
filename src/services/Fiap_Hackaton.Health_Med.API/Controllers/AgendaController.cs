using Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_Hackaton.Health_Med.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : BaseController
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(INotificator notificator, IAgendaService agendaService) : base(notificator)
        {
            _agendaService = agendaService;
        }

        [HttpGet("BuscarMedicos")]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> BuscarMedico(string especialidade, DateTime data)
        {
            var result = await _agendaService.BuscarMedicos(especialidade, data);
            return CustomResponse(result);
        }

        [HttpGet("VisualizarPedidosMedico")]
        [Authorize(Roles = "Medico")]
        public async Task<IActionResult> VisualizarPedidos()
        {
            var result = await _agendaService.VisualizarPedidos();
            return CustomResponse(result);
        }

        [HttpGet("VisualizarPedidosPaciente")]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> VisualizarPedidosPaciente()
        {
            var result = await _agendaService.VisualizarPedidosPaciente();
            return CustomResponse(result);
        }

        [HttpPost("SolicitarAgendamento")]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> SolicitarAgendamento(Guid idMedico, DateTime data)
        {
            await _agendaService.SolicitarAgendamento(data, idMedico);
            return CustomResponse();
        }

        [HttpPost("AprovarAgendamento")]
        [Authorize(Roles = "Medico")]
        public async Task<IActionResult> SolicitarAgendamento(Guid idAgendamento)
        {
            await _agendaService.AprovarAgendamento(idAgendamento);
            return CustomResponse();
        }

        [HttpDelete("RecusarConsulta")]
        [Authorize(Roles = "Medico")]
        public async Task<IActionResult> RecusarAgendamento(Guid idAgendamento)
        {
            await _agendaService.RecusarAgendamento(idAgendamento);
            return CustomResponse();
        }
    }
}
