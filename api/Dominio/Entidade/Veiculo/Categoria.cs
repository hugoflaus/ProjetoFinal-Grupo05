using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Dominio.Entidade.Veiculo
{
     [Table("categories")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string url { get; set; }

        public string Descricao { get; set; }

        [JsonIgnore]
        public List<Veiculo> Veiculos { get; set; }
    }
}