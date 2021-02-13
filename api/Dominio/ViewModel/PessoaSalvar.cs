using api.Dominio.Entidade;
using System;
using System.ComponentModel.DataAnnotations;

namespace api.Dominio.ViewModel
{
    public record PessoaSalvar 
    {
        [Required]
        public string Senha { get; set; }

        public PerfilUsuario Tipo { get; set; }

        [Required]
        public string Nome { get; set; }
 
        public DateTime Aniversario { get; set; }

        [Required]       
        public string Cep { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Complemento { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Uf { get; set; }

        [Required]
        public string Documento { get; set; }
    }
}