using System.ComponentModel.DataAnnotations;

namespace ProjetoApiEntity.Presentation.Models
{
    public class LoginModel
    {
        [EmailAddress(ErrorMessage = "Email inválido.")]
        [Required(ErrorMessage = "Por favor, informe o email de acesso.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        public string Senha { get; set; }
    }
}