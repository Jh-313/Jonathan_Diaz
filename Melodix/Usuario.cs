using System.ComponentModel.DataAnnotations;

namespace Melodix
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public string ContrasenaHash { get; set; }

        public RolUsuario Rol { get; set; } = RolUsuario.Usuario;
        public TipoSuscripcion? Suscripcion { get; set; } = TipoSuscripcion.Gratuita;

        public ICollection<Cancion>? CancionesSubidas { get; set; }
        public ICollection<Reproduccion>? Reproducciones { get; set; }
        public ICollection<Like>? Likes { get; set; }
        public ICollection<ListaReproduccion>? Listas { get; set; }
    }
}
