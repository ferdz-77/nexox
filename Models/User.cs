using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexox.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Senha { get; set; } // Armazenar a senha com hash

        [Required]
        [StringLength(20)]
        public string TipoUsuario { get; set; } // admin, artista, galeria, colecionador

        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(10)]
        public string Status { get; set; } // ativo, inativo
    }
}
