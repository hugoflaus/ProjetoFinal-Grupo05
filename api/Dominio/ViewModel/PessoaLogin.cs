using System.ComponentModel.DataAnnotations;

namespace api.Dominio.ViewModel
{
    public record PessoaLogin 
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}