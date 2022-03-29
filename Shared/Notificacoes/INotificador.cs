namespace Agendamento.Shared.Notificacoes;

public interface INotificador
{
    void Handle(Notificacao notificacao);
    List<Notificacao> ObterNotificacoes();
    bool TemNotificacao();
}

