using Agendamento.Data.Repositorios.Interfaces;
using Agendamento.Models;

namespace Agendamento.Data.Repositorios
{
    public class SalaRepositorio : Repositorio<Sala>, ISalaRepositorio
    {
        public SalaRepositorio(AgendamentoContexto context) : base(context) { }

        public Sala BuscarPorNome(string nome)
        {
            return _dbSet.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
