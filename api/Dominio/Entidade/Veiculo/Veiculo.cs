using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using api.Dominio.Entidade.Enums;

namespace api.Dominio.Entidade.Veiculo
{   
    [Table("cars")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(7)]        
        public string Placa { get; set; }

        [Required]
        public string Ano { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorHora { get; set; }

        [Required]
        public string LimitePorMalas { get; set; }
        [Required]

        public Combustivel Combustivel { get; set; }

        public string KilomentroPorLitro { get; set; }

        public string VelocidadeMaxima { get; set; }

        public int Ocupantes { get; set; }

        public string Cambio { get; set; }

        public string Potencia { get; set; }

        [Required]
        public string url {get; set;}

        public string Descricao { get; set; }

           
        [JsonIgnore]
        [Required]
        public int IdMarca { get; set; }
        public Marca Marca { get; set; }

        [JsonIgnore]
        [Required]
        public int IdModelo { get; set; }
        public Modelo Modelo { get; set; }

        [JsonIgnore]
        [Required]
        public int IdCategoria { get; set; }
        
        public Categoria Categoria { get; set; }
        
        [JsonIgnore]
        public List<Agendamento.Agendamento> Agendamentos { get; set; }

    }
}