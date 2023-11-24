using SocialNetwork.Core.Application.ViewModels.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Amigos
{
    public class AmigosViewModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Id_Usuarios { get; set; }
        public int Id_Usuarios2 { get; set; }

        //NAVIGATION PROPERTY
        public UsuariosViewModel Usuarios { get; set; }
        public UsuariosViewModel Usuarios2 { get; set; }
    }
} 
