using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using api.Dominio.Entidade.Enums;

namespace api.Dominio.Entidade.Usuario
{
    [Table("users")]
    public class Pessoa : IPessoa
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public virtual string Nome { get; set; }

        [Required]
        [MaxLength(15)]
        public virtual string Documento { get; set; }

        [Required]
        public virtual int Tipo { get; set; }

        [Required]
        [MaxLength(150)]
        public virtual string Senha { get; set; }
        public DateTime Aniversario { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public virtual PersonRole Regra { get { return (PersonRole)Enum.ToObject(typeof(PersonRole), this.Tipo); } }

        [JsonIgnore]
        public List<Agendamento.Agendamento> Agendamentos { get; set; }

    }
}