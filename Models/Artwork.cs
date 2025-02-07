using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexox.Models
{
    public class Artwork
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }

        public int AnoCriacao { get; set; }

        [Required]
        [StringLength(255)]
        public string Tecnica { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Largura { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Altura { get; set; }

        [Required]
        [StringLength(255)]
        public string Material { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Preco { get; set; } // Opcional

        [StringLength(255)]
        public string Imagem { get; set; } // URL da imagem

        public string Descricao { get; set; }

        [Required]
        [StringLength(50)]
        public bool? Status { get; set; } // ENUM: disponível, vendida, exibição, reservada

        [StringLength(255)]
        public string Localizacao { get; set; }

        [StringLength(255)]
        public string Proprietario { get; set; }

        [StringLength(255)]
        public string Exposicao { get; set; } // Exposição associada (opcional)

        [ForeignKey("Artista")]
        public int ArtistaId { get; set; }

        public virtual Artist Artista { get; set; }
    }
}
