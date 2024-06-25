using System.ComponentModel.DataAnnotations;

namespace Teste.Models
{
    public class EventosModels
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string nomedoevento { get; set; }


        [Required]
        public DateTime datadoevento { get; set; }

        [Required]
        public DateTime horariodoevento { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        
        [StringLength(100)]
        public string telefone { get; set; }
    }
}
