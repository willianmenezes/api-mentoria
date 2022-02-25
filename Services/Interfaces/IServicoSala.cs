using Agendamento.Models;
using Agendamento.Services.Dtos.Request;

namespace Agendamento.Services.Interfaces
{
    public interface IServicoSala
    {
        void Adicionar(SalaRequest salaRequest);
        void Editar(Guid id, AtualizarSalaRequest salaRequest);
        void Remover(Guid id);
        List<Sala> Buscar();
    }
}
