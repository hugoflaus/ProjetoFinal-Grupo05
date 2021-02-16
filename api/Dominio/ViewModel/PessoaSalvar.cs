using api.Dominio.Entidade;
using System;
using System.ComponentModel.DataAnnotations;

namespace api.Dominio.ViewModel
{
    public record PessoaSalvar
    {
        [Required]
        public string Senha { get; set; }

        [Required]
        public string Nome { get; set; }

        public DateTime Aniversario { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        [Required]
        public int Tipo { get; set; }

        [Required]
        public string Documento { get; set; }
    }
}