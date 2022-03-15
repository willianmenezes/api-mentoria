using Agendamento.Services.Dtos.Request;
using Agendamento.Services.Dtos.Response;

namespace Agendamento.Services.Interfaces
{
    public interface IServicoReserva
    {
        void Adicionar(Guid salaId, ReservaRequest reservaRequest);
        IEnumerable<ReservaResponse> BuscarReservasPorSala(Guid salaId);
    }
}
