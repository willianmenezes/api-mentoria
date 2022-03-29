using Agendamento.Services.Dtos.Request;
using Agendamento.Services.Interfaces;
using Agendamento.Shared.Notificacoes;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    [Route("api/agendamento")]
    public class AgendamentoController : MainController
    {
        private readonly IServicoSala _servicoSala;
        private readonly IServicoReserva _servicoReserva;

        public AgendamentoController(IServicoSala servicoSala, 
            IServicoReserva servicoReserva, INotificador notificador) : base(notificador)
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
                    return CustomResponse(ModelState);

                _servicoSala.Adicionar(salaRequest);
                return CustomResponse();
            }
            catch (Exception ex)
            {
                NotificarErro(ex.Message);
                return CustomResponse();
            }
        }

        [HttpGet("salas")]
        public IActionResult Buscar()
        {
            try
            {
                return CustomResponse(_servicoSala.Buscar());
            }
            catch (Exception ex)
            {
                NotificarErro(ex.Message);
                return CustomResponse();
            }
        }

        [HttpPatch("salas/{id}")]
        public IActionResult Atualizar([FromRoute] Guid id, [FromBody] AtualizarSalaRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);

                _servicoSala.Editar(id, request);
                return CustomResponse();
            }
            catch (Exception ex)
            {
                NotificarErro(ex.Message);
                return CustomResponse();
            }
        }

        [HttpDelete("salas/{id}")]
        public IActionResult Remover([FromRoute] Guid id)
        {
            try
            {
                _servicoSala.Remover(id);
                return CustomResponse();
            }
            catch (Exception ex)
            {
                NotificarErro(ex.Message);
                return CustomResponse();
            }
        }

        [HttpPost("salas/{id}/reservas")]
        public IActionResult CadastrarReserva([FromRoute] Guid id, [FromBody] ReservaRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);

                _servicoReserva.Adicionar(id, request);

                return CustomResponse();
            }
            catch (Exception ex)
            {
                NotificarErro(ex.Message);
                return CustomResponse();
            }
        }

        [HttpGet("salas/{id}/reservas")]
        public IActionResult BuscarReserva([FromRoute] Guid id)
        {
            try
            {
                return CustomResponse(_servicoReserva.BuscarReservasPorSala(id));
            }
            catch (Exception ex)
            {
                NotificarErro(ex.Message);
                return CustomResponse();
            }
        }
    }
}
