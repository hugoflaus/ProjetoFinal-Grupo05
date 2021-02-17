using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api.Dominio.Entidade.Agendamento
{
    [Table("checklists")]
    public class Checklist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool CarroLimpo { get; set; }

        [Required]
        public bool TanqueCheio { get; set; }

        [Required]
        public int TanqueLitroPendent { get; set; }

        [Required]
        public bool Amassados { get; set; }

        [Required]
        public bool Arranhoes { get; set; }

        [JsonIgnore]
        public Agendamento Agendamento { get; set;}

    }
}