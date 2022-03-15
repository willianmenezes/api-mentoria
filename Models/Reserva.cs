namespace Agendamento.Models
{
    public class Reserva : Entidade
    {
        private Reserva() { }

        public Reserva(
            string titulo,
            string descricao,
            DateTime inicio,
            DateTime fim,
            Guid salaId,
            Guid usuarioId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Inicio = inicio;
            Fim = fim;
            SalaId = salaId;
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public Guid SalaId { get; private set; }

        // EF RELATIONS
        public Sala Sala { get; set; }
    }
}
