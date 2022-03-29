using Agendamento.Shared.Notificacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Agendamento.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        public MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected IActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(
                    new
                    {
                        success = true,
                        data = result
                    });
            }

            return BadRequest(new
            {
                success = false,
                erros = _notificador.ObterNotificacoes()
            });
        }


        protected IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                NotificarErroComModelInvalida(modelState);

            return CustomResponse();
        }

        protected bool OperacaoValida() => !_notificador.TemNotificacao();

        private void NotificarErroComModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(x => x.Errors);

            foreach (var erro in erros)
            {
                var errorMessa = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMessa);
            }
        }

        protected void NotificarErro(string mensagem) => _notificador.Handle(new Notificacao(mensagem));
    }
}
