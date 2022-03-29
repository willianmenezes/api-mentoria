using Agendamento.Data.Repositorios.Interfaces;
using Agendamento.Models;
using Agendamento.Services.Dtos.Request;
using Agendamento.Services.Interfaces;
using Agendamento.Shared.Notificacoes;

namespace Agendamento.Services
{
    public class ServicoSala : BaseService, IServicoSala
    {
        private readonly ISalaRepositorio _salaRepositorio;

        public ServicoSala(ISalaRepositorio salaRepositorio, INotificador notificador) : base(notificador)
        {
            _salaRepositorio = salaRepositorio;
        }

        public void Adicionar(SalaRequest salaRequest)
        {
            var salaExistente = _salaRepositorio.BuscarPorNome(salaRequest.Nome);

            if (salaExistente != null)
            {
                NotificarErro("Ja existe uma sala cadastrada com esse nome");
                return;
            }

            var sala = new Sala(
                salaRequest.Nome,
                salaRequest.QuantidadeDeLugares,
                salaRequest.Andar);

            _salaRepositorio.Adicionar(sala);
        }

        public List<Sala> Buscar()
        {
            return _salaRepositorio.BuscarTodos();
        }

        public void Editar(Guid id, AtualizarSalaRequest salaRequest)
        {
            var sala = _salaRepositorio.BuscarPorId(id);

            if (sala is null)
            {
                NotificarErro("Sala inexistente.");
                return;
            }

            sala.AlterarNome(salaRequest.Nome);
            sala.AlterarQuantidadeDeLugares(salaRequest.QuantidadeDeLugares);

            _salaRepositorio.Atualizar(sala);
        }

        public void Remover(Guid id)
        {
            var sala = _salaRepositorio.BuscarPorId(id);

            if (sala is null)
            {
                NotificarErro("Sala inexistente.");
                return;
            }

            _salaRepositorio.Remover(sala);
        }
    }
}
