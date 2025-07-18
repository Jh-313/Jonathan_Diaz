using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodix
{
    public class Anuncio
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        public string UrlAudio { get; set; } // Ruta al archivo .mp3

        public string? UrlImagen { get; set; } // Opcional: imagen promocional o banner

        public bool Activo { get; set; } = true; // Solo se reproducen los activos

        public int SegundosParaOmitir { get; set; } = 3; // Tiempo en segundos para habilitar "Omitir"

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
