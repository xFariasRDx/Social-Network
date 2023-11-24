using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Usuarios
{
    public class SaveUsuariosViewModel
    {
        public int Id { get; set; }
        //------------------------------------------------//
        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        //------------------------------------------------//
        [Required(ErrorMessage = "Debe colocar un apellido")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }
        //------------------------------------------------//
        [Required(ErrorMessage = "Debe colocar un usuario")]
        [DataType(DataType.Text)]
        public string Usuario { get; set; }
        //------------------------------------------------//
        [Required(ErrorMessage = "Debe colocar un telefono")]
        [DataType(DataType.Text)]
        public string Telefono { get; set; }
        //------------------------------------------------//
        public string? Img_Profile { get; set; }
        //------------------------------------------------//
        [DataType(DataType.Upload)]
        public IFormFile? Img_Upload { get; set; }
        //------------------------------------------------//
        [Required(ErrorMessage = "Debe colocar un correo")]
        [DataType(DataType.Text)]
        public string Correo { get; set; }
        //------------------------------------------------//
        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //------------------------------------------------//
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas deben coincidir")]
        [Required(ErrorMessage = "Reescriba la contraseña")]
        [DataType(DataType.Password)]
        public string Confirm_Password { get; set; }

        //------------------------------------------------//
        public bool Verificado { get; set; } = false;
        //------------------------------------------------//
        public string? Existing { get; set; }

    }
}
