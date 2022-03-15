using Agendamento.Models;

namespace Agendamento.Data.Repositorios.Interfaces;

public interface IReservaRepositorio : IRepositorio<Reserva>
{
    public List<Reserva> BuscarReservasPorSala(Guid salaId);
}