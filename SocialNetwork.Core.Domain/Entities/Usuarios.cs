using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string? Img_Profile { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public bool Verificado { get; set; } = false;
    
        //NAVIGATION PROPERTY
        public ICollection<Amigos> Amigos { get; set; }
        public  ICollection<Amigos> Amigos2 { get; set; }
        public ICollection<Publicaciones> Publicaciones { get; set; }
        public ICollection<Comentarios> Comentarios { get; set; }
    }
}
