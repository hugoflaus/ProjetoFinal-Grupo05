using System.ComponentModel.DataAnnotations;

namespace api.Dominio.ViewModel.Pessoa
{
    public record PessoaJwt
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Token { get; set; }
        
    }
}