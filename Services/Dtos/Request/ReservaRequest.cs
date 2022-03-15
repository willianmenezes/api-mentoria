using System.ComponentModel.DataAnnotations;

namespace Agendamento.Services.Dtos.Request;

public class ReservaRequest
{
    [Required(ErrorMessage = "Titulo obrigatorio.")]
    [MaxLength(200, ErrorMessage = "Quantidade de caracteres invalida.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Descricao obrigatoria.")]
    [MaxLength(2000, ErrorMessage = "Quantidade de caracteres invalida.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Horario de inicio obrigatorio.")]
    public DateTime Inicio { get; set; }

    [Required(ErrorMessage = "Horario final obrigatorio.")]
    public DateTime Fim { get; set; }
}
