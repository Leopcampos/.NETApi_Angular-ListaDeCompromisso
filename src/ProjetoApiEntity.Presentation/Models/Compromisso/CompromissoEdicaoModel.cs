using ProjetoApiEntity.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjetoApiEntity.Presentation.Models.Compromisso
{
    public class CompromissoEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do compromisso.")]
        public Guid IdCompromisso { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do compromisso.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data do compromisso.")]
        public string Data { get; set; }

        [Required(ErrorMessage = "Por favor, informe a hora do compromisso.")]
        public string Hora { get; set; }

        [StringLength(500, MinimumLength = 6, ErrorMessage = "Por favor, informe no mínimo {2} e no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a descrição do compromisso.")]
        public string Descricao { get; set; }
    }
}