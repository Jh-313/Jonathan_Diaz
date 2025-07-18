using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodix
{
    public class ListaCancion
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("ListaReproduccion")]
        public Guid ListaReproduccionId { get; set; }
        public ListaReproduccion ListaReproduccion { get; set; }

        [ForeignKey("Cancion")]
        public Guid CancionId { get; set; }
        public Cancion? Cancion { get; set; }

        public DateTime FechaAgregado { get; set; } = DateTime.UtcNow;
    }

}
