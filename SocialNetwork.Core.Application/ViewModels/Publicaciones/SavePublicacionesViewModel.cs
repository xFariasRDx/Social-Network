using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Publicaciones
{
    public class SavePublicacionesViewModel
    {
        public int Id { get; set; }
        //------------------------------------------------//
        //------------------------------------------------//
        public string? Informacion { get; set; }
        //------------------------------------------------//
        public int Id_Usuarios { get; set; }
        //------------------------------------------------//
        public string? Img_Miniatura { get; set; }
        //------------------------------------------------//
        public string? Picture_Caption { get; set; }
        //------------------------------------------------//
        [DataType(DataType.Upload)]
        public IFormFile? Img_Upload { get; set; }
        //------------------------------------------------//
    }
}
