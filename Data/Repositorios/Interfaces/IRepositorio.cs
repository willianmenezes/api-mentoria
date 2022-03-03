using Agendamento.Models;

namespace Agendamento.Data.Repositorios.Interfaces;

public interface IRepositorio<TEntity> : IDisposable  where TEntity : Entidade
{

    void Adicionar(TEntity entity);
    void Remover(TEntity entity);
    void Atualizar(TEntity entity);
    List<TEntity> BuscarTodos();
    TEntity BuscarPorId(Guid id);
}
