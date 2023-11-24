using SocialNetwork.Core.Application.ViewModels.Amigos;
using SocialNetwork.Core.Application.ViewModels.Comentarios;
using SocialNetwork.Core.Application.ViewModels.Publicaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Usuarios
{
    public class UsuariosViewModel
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
        public ICollection<AmigosViewModel> Amigos { get; set; }
        public ICollection<AmigosViewModel> Amigos2 { get; set; }
        public ICollection<PublicacionesViewModel> Publicaciones { get; set; }
        public ICollection<ComentariosViewModel> Comentarios { get; set; }
    }
}
