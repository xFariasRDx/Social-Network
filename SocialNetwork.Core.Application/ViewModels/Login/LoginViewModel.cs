using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Login
{
    public class LoginViewModel
    {
        //------------------------------------------------//

        [Required(ErrorMessage = "Debe colocar el nombre de usuario")]
        [DataType(DataType.Text)]
        public string Usuario { get; set; }

        //------------------------------------------------//

        [Required(ErrorMessage = "Debe colocar una contraseña correcta")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //------------------------------------------------//
    }
}
