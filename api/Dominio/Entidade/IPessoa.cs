using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dominio.Entidade
{
    public interface IPessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public PerfilUsuario Tipo { get; set; }

        public DateTime Aniversario { get; set; }
        
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }
    }
}
