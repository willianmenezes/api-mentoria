using Agendamento.Models;

namespace Agendamento.Data.Repositorios.Interfaces;

public interface ISalaRepositorio : IRepositorio<Sala>
{
    Sala BuscarPorNome(string nome);
}
