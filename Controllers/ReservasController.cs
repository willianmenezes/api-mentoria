using Agendamento.Services.Dtos.Request;
using Agendamento.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        [HttpPost]
        public IActionResult Cadastrar([FromBody] ReservaRequest request) 
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Entidade Invalida");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
