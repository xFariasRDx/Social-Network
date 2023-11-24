using AutoMapper;
using SocialNetwork.Core.Application.Dtos.Email;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Login;
using SocialNetwork.Core.Application.ViewModels.Usuarios;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class UsuariosService : GenericService<Usuarios, UsuariosViewModel, SaveUsuariosViewModel>, IUsuariosServices
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IMapper _imapper;
        private readonly IEmailService _emailService;

        public UsuariosService(IUsuariosRepository usuariosRepository, IMapper imapper, IEmailService emailService) : base(usuariosRepository, imapper)
        {
            _imapper = imapper;
            _usuariosRepository = usuariosRepository;
            _emailService = emailService;
        }

        //-----------------Metodo para Registrar----------------//
        public override async Task<SaveUsuariosViewModel> Add(SaveUsuariosViewModel viewModel)
        {
            SaveUsuariosViewModel suvm = await base.Add(viewModel);

            await _emailService.SendAsync(new EmailRequest
            {
                To = suvm.Correo,
                Subject = "Welcome to Social Network",
                Body = $"<h1>Welcome to Social Network</h1> <p>Your username is {suvm.Usuario}, Verifique su correo electronico aqui: <button>https://localhost:7254/Usuarios/Verificacion/{suvm.Id}</button>"
            });

            return suvm;
        }

        //-----------------Metodo para Login----------------//
        public async Task<UsuariosViewModel> Login(LoginViewModel trae)
        {
            Usuarios usuarios = await _usuariosRepository.LoginAsync(trae);

            if (usuarios == null)
            {
                return null;
            }

            UsuariosViewModel userVm = _imapper.Map<UsuariosViewModel>(usuarios);

            return userVm;
        }

        //-----------------Metodo WithInclude----------------//
        public async Task<List<UsuariosViewModel>> GetAllAsyncWithInclude()
        {
            var usuariosList = await _usuariosRepository.GetAllAsyncWithInclude(new List<string> { "Publicaciones" });

            return usuariosList.Select(usuarios => new UsuariosViewModel
            {
                Id = usuarios.Id,
                Nombre = usuarios.Nombre,
                Apellido = usuarios.Apellido,
                Correo = usuarios.Correo,
                Telefono = usuarios.Telefono,
                Usuario = usuarios.Usuario,
                Password = usuarios.Password,
                Img_Profile = usuarios.Img_Profile,
            }).ToList();
        }

        //-----------------Metodo para Extraer by ID-------------------//

        public async Task<bool> ConfirmExist(string username)
        {
            var exist = await _usuariosRepository.GetByUserAsync(username);

            return exist != null ? true : false;
        }

        //-----------------Metodo Restore-Password----------------//

        public async Task restorePassword(string usuario)
        {
            var restore = await _usuariosRepository.GetByUserAsync(usuario);
            var newpassword = GeneratePassword.RandomPassword(10);

            restore.Password = PasswordEncryption.ComputeSha256Hash(newpassword);

            await _usuariosRepository.UpdateAsync(restore, restore.Id);

            await _emailService.SendAsync(new EmailRequest
            {
                To = restore.Correo,
                Subject = "Welcome to Social Network",
                Body = $"<h1>Social Network</h1><br><p>Hello {restore.Usuario} !<br>Su nueva contraseña es: -> {newpassword} <- ."

            });

        }
    }
}
