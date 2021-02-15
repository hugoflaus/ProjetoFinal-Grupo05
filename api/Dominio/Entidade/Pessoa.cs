using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Dominio.Entidade.Enums;

namespace api.Dominio.Entidade
{
    [Table("users")]
    public class Pessoa : IPessoa
    {
        [Key]
        [Column]
        public virtual int Id { get; set; }

        [Column]
        [Required]
        [MaxLength(100)]
        public virtual string Nome { get; set; }

        [Column]
        [Required]
        [MaxLength(15)]
        public virtual string Documento { get; set; }

        [Column]
        [Required]
        public virtual int Tipo { get; set; }

        [Column]
        [Required]
        [MaxLength(150)]
        public virtual string Senha { get; set; }

        [Column]
        public DateTime Aniversario { get; set; }

        [Column]
        public string Cep { get; set; }
        [Column]
        public string Logradouro { get; set; }
        [Column]
        public int Numero { get; set; }
        [Column]
        public string Complemento { get; set; }
        [Column]
        public string Cidade { get; set; }
        [Column]
        public string Uf { get; set; }

        [Column]
        public virtual PersonRole Regra { get { return (PersonRole)Enum.ToObject(typeof(PersonRole), this.Tipo); } }

    }
}