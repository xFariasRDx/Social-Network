using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Publicaciones
    {
        public int Id { get; set; }
        public int Id_Usuarios { get; set; }
        public string? Img_Miniatura { get; set; }
        public string? Picture_Caption { get; set; }
        public string? Informacion { get; set; }

        //NAVIGATION PROPERTY
        public Usuarios? Usuarios { get; set; }
        public ICollection<Comentarios>? Pcomentarios { get; set; }

    }
}
