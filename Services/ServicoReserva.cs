using Agendamento.Data.Repositorios.Interfaces;
using Agendamento.Models;
using Agendamento.Services.Dtos.Request;
using Agendamento.Services.Dtos.Response;
using Agendamento.Services.Interfaces;

namespace Agendamento.Services
{
    public class ServicoReserva : IServicoReserva
    {
        private readonly ISalaRepositorio _salaRepositorio;
        private readonly IReservaRepositorio _reservaRepositorio;

        public ServicoReserva(ISalaRepositorio salaRepositorio, IReservaRepositorio reservaRepositorio)
        {
            _salaRepositorio = salaRepositorio;
            _reservaRepositorio = reservaRepositorio;
        }

        public void Adicionar(Guid salaId, ReservaRequest request)
        {
            var sala = _salaRepositorio.BuscarPorId(salaId);

            if (sala is null)
                throw new Exception("Sala nao encontrada.");

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
                throw new Exception("Sala nao encontrada.");

            if (_reservaRepositorio.BuscarReservasPorSala(salaId) 
                is var reservas && reservas is null)
                return null;

            return reservas.Select(x => new ReservaResponse(x.Titulo, x.Descricao, x.Inicio, x.Fim));
        }
    }
}
