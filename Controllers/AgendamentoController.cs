using Agendamento.Services.Dtos.Request;
using Agendamento.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    [Route("api/agendamento")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IServicoSala _servicoSala;
        private readonly IServicoReserva _servicoReserva;

        public AgendamentoController(IServicoSala servicoSala, IServicoReserva servicoReserva)
        {
            _servicoSala = servicoSala;
            _servicoReserva = servicoReserva;
        }

        [HttpPost("salas")]
        public IActionResult Cadastrar([FromBody] SalaRequest salaRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Entidade Invalida");

                _servicoSala.Adicionar(salaRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("salas")]
        public IActionResult Buscar()
        {
            try
            {
                return Ok(_servicoSala.Buscar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("salas/{id}")]
        public IActionResult Atualizar([FromRoute] Guid id, [FromBody] AtualizarSalaRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Entidade Invalida");

                _servicoSala.Editar(id, request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("salas/{id}")]
        public IActionResult Remover([FromRoute] Guid id)
        {
            try
            {
                _servicoSala.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("salas/{id}/reservas")]
        public IActionResult CadastrarReserva([FromRoute] Guid id, [FromBody] ReservaRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Entidade Invalida");

                _servicoReserva.Adicionar(id, request);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("salas/{id}/reservas")]
        public IActionResult BuscarReserva([FromRoute] Guid id)
        {
            try
            {
                return Ok(_servicoReserva.BuscarReservasPorSala(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
