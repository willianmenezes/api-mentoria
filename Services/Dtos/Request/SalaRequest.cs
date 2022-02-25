using System.ComponentModel.DataAnnotations;

namespace Agendamento.Services.Dtos.Request
{
    public class SalaRequest
    {
        [Required(ErrorMessage = "Propriedade obrigatoria.")]
        [MaxLength(200, ErrorMessage = "Quantidade de caracteres invalida.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Propriedade obrigatoria.")]
        public int QuantidadeDeLugares { get; set; }

        [Required(ErrorMessage = "Propriedade obrigatoria.")]
        [Range(1, 15, ErrorMessage = "O andar deve estar entre 01 e 15.")]
        public int Andar { get; set; }
    }

    public class AtualizarSalaRequest
    {
        [Required(ErrorMessage = "Propriedade obrigatoria.")]
        [MaxLength(200, ErrorMessage = "Quantidade de caracteres invalida.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Propriedade obrigatoria.")]
        public int QuantidadeDeLugares { get; set; }
    }
}
