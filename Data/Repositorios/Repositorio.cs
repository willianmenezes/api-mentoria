using Agendamento.Data.Repositorios.Interfaces;
using Agendamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Data.Repositorios
{
    public abstract class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : Entidade
    {
        protected readonly AgendamentoContexto _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repositorio(AgendamentoContexto context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public TEntity BuscarPorId(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public List<TEntity> BuscarTodos()
        {
            return _dbSet.ToList();
        }

        public void Remover(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
