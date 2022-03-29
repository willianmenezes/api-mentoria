using Agendamento.Data.Repositorios.Interfaces;
using Agendamento.Models;
using Agendamento.Services.Dtos.Request;
using Agendamento.Services.Dtos.Response;
using Agendamento.Services.Interfaces;
using Agendamento.Shared.Notificacoes;

namespace Agendamento.Services
{
    public class ServicoReserva : BaseService, IServicoReserva
    {
        private readonly ISalaRepositorio _salaRepositorio;
        private readonly IReservaRepositorio _reservaRepositorio;

        public ServicoReserva(
            ISalaRepositorio salaRepositorio,
            IReservaRepositorio reservaRepositorio,
            INotificador notificador) : base(notificador)
        {
            _salaRepositorio = salaRepositorio;
            _reservaRepositorio = reservaRepositorio;
        }

        public void Adicionar(Guid salaId, ReservaRequest request)
        {
            var sala = _salaRepositorio.BuscarPorId(salaId);

            if (sala is null)
            {
                NotificarErro("Sala nao encontrada.");
                return;
            }

            var reserva = new Reserva(
                request.Titulo,
                request.Descricao,
                request.Inicio,
                request.Fim,
                salaId,
                Guid.Empty);

            _reservaRepositorio.Adicionar(reserva);
        }

        public IEnumerable<ReservaResponse> BuscarReservasPorSala(Guid salaId)
        {
            if (_salaRepositorio.BuscarPorId(salaId) is var sala && sala is null)
            {
                NotificarErro("Sala nao encontrada.");
                return null;
            }

            if (_reservaRepositorio.BuscarReservasPorSala(salaId)
                is var reservas && reservas is null)
                return null;

            return reservas.Select(x => new ReservaResponse(x.Titulo, x.Descricao, x.Inicio, x.Fim));
        }
    }
}
