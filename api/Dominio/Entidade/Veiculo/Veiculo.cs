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

        [Required]
        public int IdMarca { get; set; }

        [JsonIgnore]
        public Marca Marca { get; set; }

        [Required]
        public int IdModelo { get; set; }

        [JsonIgnore]
        public Modelo Modelo { get; set; }


        [Required]
        public int IdCategoria { get; set; }

		[JsonIgnore]
        public Categoria Categoria { get; set; }

    }
}