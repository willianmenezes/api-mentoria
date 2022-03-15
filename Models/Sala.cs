namespace Agendamento.Models
{
    public class Sala : Entidade
    {
        public string Nome { get; private set; }
        public int QuantidadeDeLugares { get; private set; }
        public int Andar { get; private set; }
        public bool Status { get; private set; }
        public IReadOnlyCollection<Reserva> Reservas => _reservas;
        private List<Reserva> _reservas;

        private Sala()
        {
            _reservas = new List<Reserva>();
        }

        public Sala(string nome, int quantidadeDeLugares, int andar)
        {
            Nome = nome;
            QuantidadeDeLugares = quantidadeDeLugares;
            Andar = andar;
            Status = true;

            _reservas = new List<Reserva>();
        }

        public void AlterarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("O nome nao pode estar vazio");

            Nome = nome;
        }

        public void AlterarQuantidadeDeLugares(int quantidade)
        {
            if (quantidade <= 0)
                throw new Exception("Nao eh possivel definir a quantidade de lugares com o valor informado");

            QuantidadeDeLugares = quantidade;
        }

        public void TornarAtivo() =>
            Status = true;

        public void TornarInativo() =>
            Status = false;

        public bool ReservaExistente(Reserva reserva)
        {
            if (reserva is null)
                return false;

            return _reservas.Any(x => x.Id == reserva.Id);
        }

        public void AdicionarReserva(Reserva reserva)
        {
            if (!ReservaExistente(reserva))
                _reservas.Add(reserva);
        }

        public void RemoverReserva(Reserva reserva)
        {
            if (!ReservaExistente(reserva))
                return;

            var reservaNaLista = _reservas.First(x => x.Id == reserva.Id);
            _reservas.Remove(reservaNaLista);
        }

        public void EditarReserva(Reserva reserva)
        {
            if (!ReservaExistente(reserva))
                return;

            var reservaNaLista = _reservas.First(x => x.Id == reserva.Id);
            _reservas.Remove(reservaNaLista);
            _reservas.Add(reserva);
        }
    }
}
