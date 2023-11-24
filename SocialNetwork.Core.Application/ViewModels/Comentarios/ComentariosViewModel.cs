using SocialNetwork.Core.Application.ViewModels.Publicaciones;
using SocialNetwork.Core.Application.ViewModels.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Comentarios
{
    public class ComentariosViewModel
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Usuario2 { get; set; }
        public int Id_Publicacion { get; set; }

        public UsuariosViewModel Usuarios { get; set; }
        public PublicacionesViewModel Publicaciones { get; set; }
    }
}
