using Agendamento.Data.Repositorios.Interfaces;
using Agendamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Data.Repositorios
{
    public class SalaRepositorio : ISalaRepositorio
    {
        private readonly AgendamentoContexto _context;

        public SalaRepositorio(AgendamentoContexto context)
        {
            _context = context;
        }

        public void Adicionar(Sala sala)
        {
            _context.Salas.Add(sala);
            _context.SaveChanges();
        }

        public void Atualizar(Sala sala)
        {
            _context.Salas.Update(sala);
            _context.SaveChanges();
        }

        public Sala BuscarPorId(Guid id)
        {
            return _context.Salas.FirstOrDefault(sal => sal.Id == id);
        }

        public Sala BuscarPorNome(string nome)
        {
            return _context.Salas.FirstOrDefault(sal => sal.Nome == nome);
        }

        public List<Sala> BuscarTodos()
        {
            return _context.Salas.AsNoTracking().ToList();
        }

        public void Remover(Sala sala)
        {
            _context.Salas.Remove(sala);
            _context.SaveChanges();
        }
    }
}
