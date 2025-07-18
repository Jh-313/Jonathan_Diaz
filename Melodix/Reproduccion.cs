using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodix
{
    public class Reproduccion
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
       

        [ForeignKey("Cancion")]
        public Guid CancionId { get; set; }
        
       
        public Cancion? Cancion { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
