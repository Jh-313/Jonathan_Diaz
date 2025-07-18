using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodix
{
    public class Cancion
    {
        [Key]
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public string UrlAudio { get; set; }

        [ForeignKey("SubidoPor")]
        public Guid SubidoPorId { get; set; }
       

        public int TotalLikes { get; set; }
        public int TotalReproducciones { get; set; } 
      
        public DateTime? FechaSubida { get; set; }

        public ICollection<Like>? Likes { get; set; }
        public ICollection<Reproduccion>? Reproducciones { get; set; }
        public ICollection<ListaCancion>? ListasCancion { get; set; }
    }
}
