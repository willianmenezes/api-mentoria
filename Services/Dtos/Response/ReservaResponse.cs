namespace Agendamento.Services.Dtos.Response;

public record ReservaResponse(string Titulo, string Descricao, DateTime Inicio, DateTime Fim);