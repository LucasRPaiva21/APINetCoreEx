using System.ComponentModel.DataAnnotations;

namespace APICursoNetCore.Domain.DTOs
{
    public class LoginDTO
    {
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [Required(ErrorMessage = "Email é um campo obrigatório para o Login")]      
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} carateres.")]
        public string Email { get; set; }
    }
}
