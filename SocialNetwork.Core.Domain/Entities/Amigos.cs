using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Amigos
    {
        public string Id { get; set; }
        public string Nombre { get; set; }  //QUITAR NOMBRE Y APPELIDO
        public string Apellido { get; set; }
        public int Id_Usuarios { get; set; }
        public int Id_Usuarios2 { get; set; }

        //NAVIGATION PROPERTY
        public Usuarios Usuarios { get; set; }
        public Usuarios Usuarios2 { get; set; }
    
    }

}
