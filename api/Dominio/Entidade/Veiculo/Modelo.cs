using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Dominio.Entidade.Veiculo
{
    [Table("models")]
    public class Modelo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } 

        [JsonIgnore]
        public virtual List<Veiculo> Veiculos { get; set; }
    
    }
}