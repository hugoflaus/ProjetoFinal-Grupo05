using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using api.Dominio.Entidade.Usuario;
using api.Dominio.Entidade.Veiculo;

namespace api.Dominio.Entidade.Agendamento
{
    [Table("schedule")]
    public class Agendamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataAgendamento { get; set; }

        [Required]
        public DateTime DataColetaPrevista { get; set; }

        public DateTime? DataColetaRealizada { get; set; }

        [Required]
        public DateTime DataEntregaPrevista { get; set; }

        public DateTime? DataEntregaRealizada { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public Decimal ValorHora { get; set; }

        [Required]
        public Double HorasLocacao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public Decimal SubTotal { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public Decimal CustosAdicionais { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public Decimal ValorTotal { get; set; }

        [Required]
        public bool RealizadaVistoria { get; set; }

        [Required]
        public int IdPessoa { get; set; }
        public Pessoa Pessoa  { get; set; }

        [Required]
        public int IdVeiculo { get; set; }
        public Veiculo.Veiculo Veiculo { get; set; }

        public int? IdChecklist { get; set; }
        public Checklist Checklist { get; set; }
    }
}