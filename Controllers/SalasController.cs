using Agendamento.Services.Dtos.Request;
using Agendamento.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly IServicoSala _servicoSala;
        public SalasController(IServicoSala servicoSala)
        {
            _servicoSala = servicoSala;
        }

        [HttpPost]
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

        [HttpGet]
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

        [HttpPatch("{id}")]
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

        [HttpDelete("{id}")]
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
    }
}
