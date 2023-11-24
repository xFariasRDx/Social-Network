using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.ViewModels.Comentarios;
using SocialNetwork.Core.Application.ViewModels.Publicaciones;
using SocialNetwork.Core.Application.ViewModels.Usuarios;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class ComentariosService : GenericService<Comentarios, ComentariosViewModel, SaveComentariosViewModel>
    { 

        private readonly IComentariosRepository _repository;
        private readonly IMapper _imapper;
        private readonly ComentariosViewModel viewModel;
        private readonly IHttpContextAccessor _contextAccessor;

        public ComentariosService(IComentariosRepository repository, IMapper imapper) : base(repository, imapper)
        {
            _imapper = imapper;
            _repository = repository;
        }

        ////-----------------Metodo WithInclude----------------//
        //public async Task<List<ComentariosViewModel>> GetAllAsyncWithInclude()
        //{
        //    var commentsList = await _repository.GetAllAsyncWithInclude(new List<string> { "Usuarios", "Pcomentarios" });

        //    return commentsList.Where(p => p.Id_Publicacion == _usuariosViewModel.Id).Select(publicaciones => new PublicacionesViewModel
        //    {
        //        Id = publicaciones.Id,
        //        Id_Usuarios = publicaciones.Id_Usuarios,
        //        Informacion = publicaciones.Informacion,
        //        Username = viewModel.Usuario,
        //        Img_Miniatura = viewModel.Img_Profile,
        //        Picture_Caption = publicaciones.Picture_Caption

        //    }).ToList();
        //}

    }
}
