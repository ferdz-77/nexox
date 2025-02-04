using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexox.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string Biografia { get; set; }

        [StringLength(20)]
        public string Celular { get; set; }

        [StringLength(255)]
        public string Foto { get; set; } // URL da foto do artista

        [Required]
        [StringLength(10)]
        public string Status { get; set; } // ativo, inativo
    }
}
