using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodix
{
    public class ListaReproduccion
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public DateTime? FechaCreacion { get; set; } = DateTime.UtcNow;

        public ICollection<ListaCancion>? ListasCancion { get; set; }
    }

}
