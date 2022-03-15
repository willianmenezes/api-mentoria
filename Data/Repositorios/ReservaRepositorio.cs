using Agendamento.Data.Repositorios.Interfaces;
using Agendamento.Models;

namespace Agendamento.Data.Repositorios
{
    public class ReservaRepositorio : Repositorio<Reserva>, IReservaRepositorio
    {
        public ReservaRepositorio(AgendamentoContexto context) : base(context) { }

        public List<Reserva> BuscarReservasPorSala(Guid salaId)
        {
            return _dbSet.Where(r => r.SalaId == salaId).ToList();
        }
    }
}
