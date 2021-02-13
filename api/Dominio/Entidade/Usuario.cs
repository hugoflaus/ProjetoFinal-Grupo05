using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dominio.Entidade
{
    [Table("users")]
    public class Usuario : IPessoa
    {
        [Key]
        [Column]
        public int Id { get; set; }     

        [Required]
        [MaxLength(100)]
        [Column]
        public string Senha { get; set; }

        public PerfilUsuario Tipo { get; set; }

        [Required]
        [MaxLength(100)]
        [Column]
        public string Nome { get; set; }

        [Column]
        public DateTime Aniversario { get; set; }

        [Column]
        [Required]
        [MaxLength(10)]
        public string Cep { get; set; }

        [Column]
        [Required]
        public string Logradouro { get; set; }

        [Column]
        [Required]
        public int Numero { get; set; }

        [Column]
        [Required]
        public string Complemento { get; set; }

        [Column]
        [Required]
        public string Cidade { get; set; }

        [Column]
        [Required]
        public string Uf { get; set; }

        [Column]
        [Required]
        public string Documento { get; set; }
    }
}
