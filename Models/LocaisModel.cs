using System.ComponentModel.DataAnnotations;

namespace Teste.Models
{    public class LocaisModels
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string nomedolocal { get; set; }

        [StringLength(30)]
        public string apelido { get; set; }

        [StringLength(30)]
        public string cnpj { get; set; }

        [Required]
        [StringLength(100)]
        public string cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string uf { get; set; }

        [Required]
        [StringLength(100)]
        public string cep { get; set; }

        [Required]
        [StringLength(20)]
        public string endereco { get; set; }

        [StringLength(20)]
        public string complemento { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string telefone { get; set; }

        [StringLength(100)]
        public string cadastroentradas { get; set; }


        [StringLength(100)]
        public string cadastrodecatracas { get; set; }
    }
}
