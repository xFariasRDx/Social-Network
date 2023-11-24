using SocialNetwork.Core.Application.ViewModels.Comentarios;
using SocialNetwork.Core.Application.ViewModels.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Publicaciones
{
    public class PublicacionesViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? Informacion { get; set; }
        public string? Img_Miniatura { get; set; }
        public string? Picture_Caption { get; set; }
        public int Id_Usuarios { get; set; }

        //NAVIGATION PROPERTY
        public UsuariosViewModel? Usuarios { get; set; }
        public ICollection<SaveComentariosViewModel>? Pcomentarios { get; set; }
    }
}
