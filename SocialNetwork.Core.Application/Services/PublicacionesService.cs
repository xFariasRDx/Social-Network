using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocialNetwork.Core.Application.Dtos.Email;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
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
    public class PublicacionesService : GenericService<Publicaciones, PublicacionesViewModel, SavePublicacionesViewModel>, IPublicacionesServices
    {
        private readonly IPublicacionesRepository _repository;
        private readonly IMapper _imapper;
        private readonly UsuariosViewModel _usuariosViewModel;
        private readonly IHttpContextAccessor _contextAccessor;

        public PublicacionesService(IPublicacionesRepository repository, IMapper imapper, IHttpContextAccessor contextAccessor) : base(repository, imapper)
        {
            _imapper = imapper;
           _repository = repository;
            _contextAccessor= contextAccessor;
            _usuariosViewModel = _contextAccessor.HttpContext.Session.Get<UsuariosViewModel>("Usuarios");
        }
        //-----------------Metodo para----------------//

        public override async Task Update(SavePublicacionesViewModel vm, int id)
        {
            vm.Id_Usuarios = _usuariosViewModel.Id;

            await base.Update(vm, id);
        }

        //-----------------Metodo para Registrar----------------//
        public override async Task<SavePublicacionesViewModel> Add(SavePublicacionesViewModel viewModel)
        {

            viewModel.Id_Usuarios = _usuariosViewModel.Id;
            viewModel.Img_Miniatura = _usuariosViewModel.Img_Profile;

            return await base.Add(viewModel);

        }
        //-----------------Metodo WithInclude----------------//
        public async Task<List<PublicacionesViewModel>> GetAllAsyncWithInclude()
        {
            var publicList = await _repository.GetAllAsyncWithInclude(new List<string> { "Usuarios", "Pcomentarios" });
        
            return publicList.Where(p => p.Id_Usuarios == _usuariosViewModel.Id).Select( publicaciones => new PublicacionesViewModel
            {
                Id= publicaciones.Id,
                Id_Usuarios = publicaciones.Id_Usuarios,
                Informacion = publicaciones.Informacion,
                Username = _usuariosViewModel.Usuario,
                Img_Miniatura = _usuariosViewModel.Img_Profile,
                Picture_Caption = publicaciones.Picture_Caption

            }).ToList();
        }

    }
}
