namespace Agendamento.Models
{
    public class Usuario : Entidade
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Permissao { get; private set; }
    }
}
