using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Comentarios
{
    public class SaveComentariosViewModel
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Usuario2 { get; set; }
        public int Id_Publicacion { get; set; }
    }
}
