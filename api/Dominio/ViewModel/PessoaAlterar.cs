using System;

namespace api.Dominio.ViewModel
{
    public record PessoaAlterar
    {  
        public string Nome { get; set; }

        public DateTime Aniversario { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public int Tipo { get; set; }

        public string Documento { get; set; }
        
    }
}